﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morters_App
{
    public partial class Form3 : Form
    {
        //variabler för kundköp
        int kkx;
        int personnummer;

        //variabler för inköp
        int ikx;
        string leverantor;
        int ikpris;

        List<string> stringList = new List<string>();

        public Form3()
        {
            DatabaseResolver.Connect();
            InitializeComponent();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            foreach (string s in DatabaseResolver.GetAllTypes())
                stringList.Add(s);
            listBox1.DataSource = stringList;
            stringList.Clear();
            listBox3.DataSource = null;
            listBox3.Items.Clear();
            listBox3.DataSource = DatabaseResolver.columnList;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            listBox2.Items.Clear();
            try
            {
                stringList.Clear();
                foreach (string s in DatabaseResolver.GetInformation(listBox1.SelectedItem.ToString()))
                    stringList.Add(s);
            }
            catch (NullReferenceException)
            {
            }
            listBox2.DataSource = stringList;
            stringList.Clear();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
