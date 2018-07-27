using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraTimeTracker
{
    public partial class JTT : Form
    {
        private ConnectionHandler connectionHandler;
        private JTT window;

        public JTT()
        {
            InitializeComponent();
        }

        private void JTT_Load(object sender, EventArgs e)
        {

        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            connectionHandler = new ConnectionHandler(window.UrlTextBox.Text, window.ApiTokenTextBox.Text, window.UsernameTextBox.Text, window.PasswordTextBox.Text);
            connectionHandler.TestConnection();
        }
    }
}
