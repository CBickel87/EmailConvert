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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

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
                //listBox1.Items.Add(string.Join(Environment.NewLine, s)); // add item to listbox
                var names = s1.Split(',');
                string lastname = names[0];
                string firstname = names[1];
                //textBox2.Text = (firstname + "." + lastname + "@email.com");

                // create your domain context
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                // define a "query-by-example" principal - here, we search for a UserPrincipal 
                // and with the first name (GivenName) of "Bruce" and a last name (Surname) of "Miller"
                UserPrincipal qbeUser = new UserPrincipal(ctx);
                qbeUser.GivenName = names[1];
                qbeUser.Surname = names[0];

                // create your principal searcher passing in the QBE principal    
                PrincipalSearcher srch = new PrincipalSearcher(qbeUser);

                // find all matches
                foreach (var found in srch.FindAll())
                {
                    // do whatever here - "found" is of type "Principal" - it could be user, group, computer.....
                    //MessageBox.Show(found.UserPrincipalName);

                    textBox2.Text = found.UserPrincipalName;

                }

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
