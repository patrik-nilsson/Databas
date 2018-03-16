using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mortfors_vitvaror_kundinterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            bool boolfound = false;
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=pgserver.mah.se; Port=5432; UserId = ah7326; Password = emmodj9b; Database = ah7326"))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT version(); ", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
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
                using (var cmd2 = new NpgsqlCommand("SELECT * FROM Tavling", conn))
                {
                    using (var reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                            textBox1.Text += reader.GetString(1);
                    }
                }
                dr.Close();

            }
            Console.ReadLine();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
