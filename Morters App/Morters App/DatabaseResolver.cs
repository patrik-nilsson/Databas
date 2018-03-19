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
        static NpgsqlCommand cmd;
        static NpgsqlDataReader dr;
        static List<string> stringList = new List<string>();
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
        }
        public static List<string> GetTavling()
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT * FROM Kunder", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(1)+"\r");
            dr.Close();
            return stringList;
        }
    }
}
