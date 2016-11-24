using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace ADS_MD5CryptoServiceProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // create hash code for a given string
            MD5CryptoServiceProvider myhash = new MD5CryptoServiceProvider();
            String value = "abc";// this is the password
            String hash = "";
            String output = "";
            // create hash value for the string and convert it to a hash value and store it in a byte array
            byte[] hashArray = myhash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(value));
            //convert the hash value in to a hexadecimal format
            for (int i = 0; i < hashArray.Length; i++)
                hash = String.Format("{0:X2}", hashArray[i]);
            txtOutput.Text = hash + "\r\n";
            //compare hash codes
            String input = Interaction.InputBox("Enter a string value", "Enter string"); // get a string value from the user
                                                                                                               // convert it to a hash value and store it in a byte array
            byte[] hashArray2 = myhash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
            //convert the hash value in to a hexadecimal format
            for (int i = 0; i < hashArray2.Length; i++)
                output = String.Format("{0:X2}", hashArray2[i]);
            if (output.Equals(hash)) // use the Equals method in the MD5CryptoServiceProvider class to compare objects
                txtOutput.Text += "You entered the right value";
            else
                txtOutput.Text += "You entered the wrong value";
        }
    }
}
