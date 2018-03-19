﻿using System;
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
        public static List<string> GetAllTypes()
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0)+"\r");
            dr.Close();
            return stringList;
        }
        public static List<string> GetType(string type)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT namn FROM Vitvaror WHERE typ='"+type+"'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0) + "\r");
            dr.Close();
            return stringList;
        }
        public static List<string> GetManufacturer(string manufacturer)
        {
            stringList.Clear();
            cmd = new NpgsqlCommand("SELECT tillverkare FROM Vitvaror WHERE tillverkare='" + manufacturer + "'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                stringList.Add(dr.GetString(0) + "\r");
            dr.Close();
            return stringList;
        }
    }
}