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
            try {
            textBox2.Clear();
            textBox3.Clear();
            textBox2.CharacterCasing = CharacterCasing.Lower;
            textBox3.CharacterCasing = CharacterCasing.Lower;

            //Splitting and removing ; character also remove empty entries to prevent crashes.
            char[] delimiterChars = new Char[] {';'};
            string[] words = textBox1.Text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            //Split further by commas and remove spaces from the entry.
            //Distinguish First and Lastnames and set those into variables
            foreach (string s in words)
            {
                    var names = s.Trim().Split(',');
                    string lastname = names[0];
                    string firstname = names[1];

                //If user has middle initial in name layout. It removes it to prevent mismatch
                //TODO : This was a temp fix so it would work. I'll come back and fix this.
                if (firstname.Contains('.'))
                    firstname = firstname.Substring(0, firstname.LastIndexOf(' '));

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
                        textBox3.Text += found.DisplayName + "\r\n";
                    }
                    else
                    {
                        textBox2.Text += found.UserPrincipalName + "\r\n";
                    }

                    Clipboard.SetText(textBox2.Text);
                }

                }
                
           }
            //Catch those pesky exceptions
            catch
            {
                MessageBox.Show("Make sure the format is Lastname, Firstname;" + 
                    "\r\n" + "Each new user must end with a semi colon." +
                    "\r\n" + "Distrobution groups cannot be used." +
                    "\r\n" + "This will only work on an AD network.", "Check Formatting");
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