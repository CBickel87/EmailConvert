using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EmailConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ';'};
            string text = textBox1.Text;
            string[] words = text.Split(delimiterChars);
           
            foreach (string s in words)
            {
                string s1 = s.Trim();
                //listBox1.Items.Add(string.Join(Environment.NewLine, s));
                var names = s1.Split(',');
                string lastname = names[0];
                string firstname = names[1];
                textBox2.Text = (firstname + "." + lastname + "@email.com");

                //listBox1.Items.Add(string.Join(Environment.NewLine, names));
                //listBox1.Items.Add(string.Join(Environment.NewLine, firstname + "." + lastname + "@email.com"));
            }
            //{
            //string fullname = textBox1.Text;
            //var newname = fullname.Split(';');
            //i = newname[0++];

            //listBox1.Items.Add(string.Join(Environment.NewLine, newname[3]));

            //string fullname = (s);
            //var names = s.Split(',');
            //string lastname = names[0];
            //string firstname = names[1];

            //listBox1.Items.Add(string.Join(Environment.NewLine, firstname + "." + lastname + "@email.com"));
           // }
        }
       
    }
}
