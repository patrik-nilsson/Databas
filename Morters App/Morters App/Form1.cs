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
        int lbindex1;
        public Form1()
        {
            DatabaseResolver.Connect();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            listBox2.Items.Clear();
            string curItem = listBox1.SelectedItem.ToString();
            lbindex1 = listBox1.FindString(curItem);
            if (lbindex1 == 0)
            {
                foreach (string s in DatabaseResolver.GetAllTypes())
                {
                    stringList.Add(s);
                }
                listBox2.DataSource = stringList;
                stringList.Clear();
            }
            else
            {
                foreach (string s in DatabaseResolver.GetType(listBox1.SelectedItem.ToString()))
                    stringList.Add(s);
                listBox2.DataSource = stringList;
                stringList.Clear();
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
