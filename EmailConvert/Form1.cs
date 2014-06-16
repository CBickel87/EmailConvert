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
            textBox3.Clear();
            char[] delimiterChars = new Char[] { ';' };
            string[] words = textBox1.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in words)
            {
                var names = s.Trim().Split(',');
                string lastname = names[0];
                string firstname = names[1];

                //If user has middle initial in name layout. It removes it to prevent mismatch
                if (firstname.Contains('.'))
                    firstname = firstname.Substring(0, firstname.LastIndexOf(' '));

                    ////This was for testing without being on the AD.
                    //richTextBox1.Text += (firstname + "." + lastname + "@email.com" + "\r\n");
                    //MessageBox.Show(firstname + "." + lastname + "@email.com");

                    /// <summary> 
                    /// The code for querying AD was taken from marc_s @:
                    /// http://stackoverflow.com/questions/9603878/how-can-i-search-users-in-active-directory-based-on-name-and-first-name
                    /// </summary>


                // create your domain context
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                // define a "query-by-example" principal - here, we search for a UserPrincipal 
                // and with the first name (GivenName) of "Bruce" and a last name (Surname) of "Miller"
                UserPrincipal qbeUser = new UserPrincipal(ctx);
                qbeUser.GivenName = firstname;
                qbeUser.Surname = lastname;

                // create your principal searcher passing in the QBE principal    
                PrincipalSearcher srch = new PrincipalSearcher(qbeUser);

                // find all matches
                foreach (var found in srch.FindAll())
                {
                    // do whatever here - "found" is of type "Principal" - it could be user, group, computer.....
                    //Prints to richTextbox1 and copies it all to clipboard at the same time
                    if (found.UserPrincipalName.Contains(" "))
                    {
                        textBox3.Text += found.UserPrincipalName + "\r\n";
                    }
                    else
                    {
                        textBox2.Text += found.UserPrincipalName + "\r\n";
                    }

                   Clipboard.SetText(textBox2.Text);
                }

                }
                
           }

        //Click clear button and clears richtextbox1
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }

    }
       
}
