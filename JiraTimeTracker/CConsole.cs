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
        public CConsole(TextBox outputTextBox)
        {
            outputBox = outputTextBox;
        }

        public void Write(string text)
        {
            if(text != null)
            {
                outputBox.Text += "\r\n" + text;
            }
        }
    }
}
