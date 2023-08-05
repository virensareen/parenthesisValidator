using System;
using System.IO;
using System.Windows.Forms;

namespace Parenthesis_Validator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ValidateParentheses();
        }

        private void ValidateParentheses()
        {
            var filePath = "parenthesis_data.csv";

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (IsValid(line))
                    {
                        listBox.Items.Add(line);
                    }
                }
            }
        }

        private bool IsValid(string input)
        {
            int openCount = 0;

            foreach (char c in input)
            {
                if (c == '(')
                {
                    openCount++;
                }
                else if (c == ')')
                {
                    openCount--;

                    if (openCount < 0)
                    {
                        return false;
                    }
                }
            }

            return openCount == 0;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
