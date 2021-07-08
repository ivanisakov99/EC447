using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Title
            this.Text = "Ivan Isakov - Lab 4";
        }

        private void Generate_Btn_Click(object sender, EventArgs e)
        {
            // Button Text
            this.Text = "Generate";

            // Palindrome List 
            List<int> palindromes = new List<int>();

            // Error check the size of the input
            if (Start_Num.Text.Length <= 0 || Start_Num.Text.Length > 10 || Select_Range.Text.Length <= 0 || Select_Range.Text.Length > 10)
            {
                // Display an empty list
                P_List.DataSource = palindromes;

                // Issue a Warning
                //Int_Warning.Text = "Please enter a positive integer within range.";
                Int_Warning.Visible = true;
                return;
            }

            // Make sure each character is a digit
            for (int i = 0; i < Start_Num.Text.Length; i++)
            {
                if (Start_Num.Text[i] < '0' || Start_Num.Text[i] > '9')
                {
                    // Display an empty list
                    P_List.DataSource = palindromes;

                    // Issue a Warning
                    Int_Warning.Visible = true;
                    return;
                }
            }

            // Make sure each character is a digit
            for (int i = 0; i < Select_Range.Text.Length; i++)
            {
                if (Select_Range.Text[i] < '0' || Select_Range.Text[i] > '9')
                {
                    // Display an empty list
                    P_List.DataSource = palindromes;

                    // Issue a Warning
                    Int_Warning.Visible = true;
                    return;
                }
            }

            // Convert each input to an integer
            int start = Convert.ToInt32(Start_Num.Text), range = Convert.ToInt32(Select_Range.Text);

            // Error check (e.g. range = '00')
            if (start < 0 || start > 1000000000 || range < 1 || range > 100)
            {
                // Display an empty list
                P_List.DataSource = palindromes;

                // Issue a Warning
                Int_Warning.Visible = true;
                return;
            }

            // Passed every error check, clear the warning
            Int_Warning.Visible = false;

            // Valid palindrome
            bool b;

            // Temporary string variable to test an integer for being a palindrome
            string temp;
            
            // Size of the potential palindrome
            int n;
            while (range > 0)
            {
                b = true;

                temp = start.ToString();

                n = temp.Length;

                // Check if its a valid palindrome
                for (int i = 0; i < n; i++)
                {
                    if (temp[i] != temp[n - 1 - i])
                    {
                        b = false;
                        break;
                    }
                }

                // If yes, add it to the list
                if (b)
                {
                    palindromes.Add(start);
                    range--;
                }

                // Test the next value
                start++;
            }

            // List box will display the palindromes
            P_List.DataSource = palindromes;
        }
    }
}
