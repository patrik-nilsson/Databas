using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Threading;

namespace Morters_App
{
    static class DatabaseResolver
    {
        static bool boolfound = false;
        static NpgsqlConnection conn = new NpgsqlConnection("Server=pgserver.mah.se; Port=5432; UserId = ah7326; Password = emmodj9b; Database = vitvaruhandel");
        public static NpgsqlCommand cmd;
        static NpgsqlDataReader dr;
        static List<string> stringList = new List<string>();
        public static List<string> typeList = new List<string>();
        public static List<string> columnList = new List<string>();

        static int ikid;
        static int x;

        public static void Connect()
        {
            conn.Open();
            cmd = new NpgsqlCommand("SELECT version(); ", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                boolfound = true;
                Console.WriteLine("connectionestablished");
                Console.WriteLine("{0}", dr[0]);
            }
            if (boolfound == false)
            {
                Console.WriteLine("Data does not exist");
            }
            dr.Close();
            cmd = new NpgsqlCommand("SELECT typ FROM Vitvaror GROUP BY typ", conn);
            dr = cmd.ExecuteReader();
            typeList.Clear();
            typeList.Add("Alla");
            while (dr.Read())
            {
                typeList.Add(dr.GetString(0));
            }
            dr.Close();
            columnList.Clear();
            cmd = new NpgsqlCommand("SELECT column_name FROM information_schema.columns WHERE table_name = 'vitvaror'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                columnList.Add(dr.GetString(0));
            }
            columnList.RemoveAt(0);
            dr.Close();
        }
        public static void Disconnect()
        {
            try
            {
                conn.Close();
            }
            catch (InvalidCastException e)
            {
            }

        }
        public static List<string> GetAllTypes()
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0));
            dr.Close();
            return stringList;
        }
        public static List<string> GetAllManufacturers()
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT tillverkare FROM Vitvaror", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0));
            dr.Close();
            return stringList;
        }
        public static List<string> GetItems(string type, string manufacturer)
        {
            stringList.Clear();
            if (type == "Alla" && manufacturer == "Alla")
                cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror", conn);
            else if (type == "Alla")
                cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror WHERE tillverkare='" + manufacturer + "'", conn);
            else if (manufacturer == "Alla")
                cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror WHERE typ='" + type + "'", conn);
            else
                cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror WHERE typ='"+type+"' AND tillverkare='"+manufacturer+"'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0));
            dr.Close();
            return stringList;
        }
        public static List<string> GetManufacturers(string type)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT tillverkare FROM Vitvaror WHERE typ='" + type + "'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0));
            dr.Close();
            return stringList;
        }
        public static List<string> GetInformation(string item)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT * FROM Vitvaror WHERE namn='" + item + "'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stringList.Add(dr.GetString(1));
                stringList.Add(dr.GetString(2));
                stringList.Add(dr.GetString(3));
                stringList.Add(dr.GetString(4));
                stringList.Add(dr.GetString(5));
                stringList.Add(dr.GetString(6));
            }
            dr.Close();
            return stringList;
        }
        public static List<string> GetColumns(string item)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT * FROM information_schema.columns WHERE table_schema = 'table_columns' AND table_name = 'Vitvaror'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stringList.Add(dr.GetString(0));
            }
            dr.Close();
            return stringList;
        }

        public static List<string> GetTables(string item)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT adress FROM Kunder", conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                stringList.Add(dr.GetString(0));
            }
            dr.Close();
            return stringList;
        }

        public static string GetItemID(string item)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT v_id FROM Vitvaror WHERE namn='" + item + "'", conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                stringList.Add(dr.GetString(0));
            }
            dr.Close();
            return stringList[0];
        }
        public static bool CreateInkop(int item, int amount, string deliverer, int price)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT l_id FROM Leverantor WHERE namn='" + deliverer + "'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stringList.Add(dr.GetString(0));
            }
            dr.Close();

            cmd = new NpgsqlCommand("SELECT i_id FROM Inkop WHERE i_id = (SELECT max(i_id) FROM Inkop)", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ikid = Convert.ToInt32(dr.GetString(0));
                ikid++;
            }
            dr.Close();

            cmd = new NpgsqlCommand("INSERT INTO Inkop VALUES(" + ikid +"," + item + "," + Convert.ToInt32(stringList[0]) + "," + price + "," + amount + ")", conn);
            dr = cmd.ExecuteReader();
            dr.Close();

            return true;
        }
        public static void IncreaseAmount(int item, int amount)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT antal FROM Vitvaror WHERE v_id='" + item + "'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                x = Convert.ToInt32(dr.GetString(0)) + amount;
            }
            dr.Close();
            cmd = new NpgsqlCommand("UPDATE Vitvaror SET antal=" + x + " WHERE v_id=" + item, conn);
            dr = cmd.ExecuteReader();
            dr.Close();
        }
    }
}
