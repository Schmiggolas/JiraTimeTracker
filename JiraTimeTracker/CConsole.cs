using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraTimeTracker
{
    class CConsole
    {
        private TextBox outputBox;
        private TextBox userOutputTextBox;

        public CConsole(TextBox outputTextBox, TextBox userOutputTextBox)
        {
            outputBox = outputTextBox;
            this.userOutputTextBox = userOutputTextBox;
        }

        public void WriteOutput(string text)
        {
            if(text != null)
            {
                outputBox.Text += "\r\n" + text;
            }
        }

        public void WriteUserList(string text)
        {
            if (text != null)
            {
                userOutputTextBox.Text = text;
            }
        }
    }
}
