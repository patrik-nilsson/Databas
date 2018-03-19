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
        public Form1()
        {
            DatabaseResolver.Connect();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(richTextBox1.TextLength>0)
                richTextBox1.Text = null;
            string curItem = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(curItem);
            if (index == 0)
                foreach (string s in DatabaseResolver.GetTavling())
                    richTextBox1.Text += s;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
