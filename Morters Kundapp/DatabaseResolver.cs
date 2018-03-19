using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Morters_Kundapp
{
    static class DatabaseResolver
    {
        static bool boolfound = false;
        static NpgsqlConnection conn = new NpgsqlConnection("Server=pgserver.mah.se; Port=5432; UserId = ah7326; Password = emmodj9b; Database = ah7326");
        static NpgsqlCommand cmd = new NpgsqlCommand("SELECT version(); ", conn);
        static NpgsqlDataReader dr = cmd.ExecuteReader();
        public static void Connect()
        {
            dr.Close();
            conn.Open();
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
        public static void GetTavling()
        {
            using (var cmd2 = new NpgsqlCommand("SELECT * FROM Tavling", conn))
            {
                using (var reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(1));
                }
            }
            dr.Close();
        }
    }
}
