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
        private JTT form;

        public JTT()
        {
            InitializeComponent();
            SetActiveForm();
        }

        private JTT SetActiveForm()
        {
            if (form == null)
            {
                form = Form.ActiveForm as JTT;
                return form;
            }
            return form;
        }

        private void JTT_Load(object sender, EventArgs e)
        {

        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            SetActiveForm();
            connectionHandler = new ConnectionHandler(form.UrlTextBox.Text, form.LoginTextBox.Text, form.PasswordTextBox.Text);
            connectionHandler.TestConnection();
        }
    }
}
