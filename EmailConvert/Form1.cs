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
            textBox2.Clear();
            char[] delimiterChars = new Char[] {';'};
            string[] words = textBox1.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in words)
                {
                    var names = s.Trim().Split(',');
                    string lastname = names[0];
                    string firstname = names[1];
                    textBox2.Text += (firstname + "." + lastname + "@email.com" + "\r\n");
                    //MessageBox.Show(firstname + "." + lastname + "@email.com");

                    //// create your domain context
                    //PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                    //// define a "query-by-example" principal - here, we search for a UserPrincipal 
                    //// and with the first name (GivenName) of "Bruce" and a last name (Surname) of "Miller"
                    //UserPrincipal qbeUser = new UserPrincipal(ctx);
                    //qbeUser.GivenName = names[1];
                    //qbeUser.Surname = names[0];

                    //// create your principal searcher passing in the QBE principal    
                    //PrincipalSearcher srch = new PrincipalSearcher(qbeUser);

                    //// find all matches
                    //foreach (var found in srch.FindAll())
                    //{
                    //    // do whatever here - "found" is of type "Principal" - it could be user, group, computer.....
                    //    //MessageBox.Show(found.UserPrincipalName);
                    //    textBox2.Text += found.UserPrincipalName + "\r\n";
                    //    //Clipboard.SetText += (found.UserPrincipalName);

                    //}
                }
                
           }

        ////Trying to add Ctr+A shortcut to select all. Defaults off for multiline txtboxes
        //private void textBox2_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.A)
        //    {
        //        textBox2.SelectAll();
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

    }
       
}
