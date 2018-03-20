using System;
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
    public partial class Form1 : Form
    {
        List<string> stringList = new List<string>();
        List<string> compareList = new List<string>();
        int lbindex1;
        int lbindex2;


        public Form1()
        {
            DatabaseResolver.Connect();
            InitializeComponent();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.DataSource = DatabaseResolver.typeList;
            listBox4.DataSource = null;
            listBox4.Items.Clear();
            listBox4.DataSource = DatabaseResolver.columnList;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox5.DataSource = null;
            listBox5.Items.Clear();
            string curItem = listBox1.SelectedItem.ToString();
            lbindex1 = listBox1.FindString(curItem);
            if (lbindex1 == 0)
            {
                stringList.Add("Alla");
                foreach (string s in DatabaseResolver.GetAllManufacturers())
                {
                    stringList.Add(s);
                }
                listBox5.DataSource = stringList;
                stringList.Clear();
            }
            else
            {
                stringList.Add("Alla");
                foreach (string s in DatabaseResolver.GetManufacturers(listBox1.SelectedItem.ToString()))
                    stringList.Add(s);
                listBox5.DataSource = stringList;
                stringList.Clear();
            }
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            listBox2.Items.Clear();
            try
            {
                stringList.Clear();
                foreach (string s in DatabaseResolver.GetItems(listBox1.SelectedItem.ToString(), listBox5.SelectedItem.ToString()))
                    stringList.Add(s);
                listBox2.DataSource = stringList;
                stringList.Clear();
            }
            catch (NullReferenceException)
            {
            }
}
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.DataSource = null;
            listBox3.Items.Clear();
            try
            {
                stringList.Clear();
                foreach (string s in DatabaseResolver.GetInformation(listBox2.SelectedItem.ToString()))
                    stringList.Add(s);
            }
            catch (NullReferenceException)
            {
            }
            listBox3.DataSource = stringList;
            compareList.Clear();
            foreach (string s in stringList)
                compareList.Add(s);
            stringList.Clear();
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox6.DataSource = null;
            listBox6.Items.Clear();
            listBox6.DataSource = compareList;
        }
    }
}
