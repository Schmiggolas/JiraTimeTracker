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
        private CConsole cConsole;

        public JTT()
        {
            InitializeComponent();
        }

        private void JTT_Load(object sender, EventArgs e)
        {
            SetActiveForm();
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            InitializeOutput();
        }

        private JTT SetActiveForm()
        {
            if (form == null)
            {
                form = this;
                
                return form;
            }
            return form;
        }

        private void InitializeOutput()
        {
            cConsole = new CConsole(form.OutputTextBox, form.UserTextBox);
        }

        private ConnectionHandler GetConnectionHandler()
        {
            if(connectionHandler == null)
            {
                connectionHandler = new ConnectionHandler(UrlTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text,cConsole);
                return connectionHandler;
            }
            connectionHandler.UpdateVariables(UrlTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
            return connectionHandler;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if (GetConnectionHandler().TestConnection())
            {
                cConsole.WriteOutput("Test Successfull");
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GetConnectionHandler();
            GetTimeForUser();
        }

        private void GetTimeForUser()
        {
            var result = GetWorkingTime();
            if(result != null)
            {
                cConsole.WriteOutput("Working hours for user " + UsernameTextBox.Text + " : " + result);
            }
            else
            {
                cConsole.WriteOutput("An error occured. Is there a typo in the provided username?");
            }
        }

        private string GetWorkingTime()
        {
            var queryresult = GetConnectionHandler().GetAssignedIssuesForUser(UsernameTextBox.Text,ProjectKeyTextBox.Text);
            if(queryresult != null)
            {
                JsonConv conv = new JsonConv();
                IssuesRoot decoderesult =  conv.DecodeJsonToIssuesRoot(queryresult);
                int timeinseconds = CalculateWorkingTimeInSeconds(decoderesult);
                conv = null;
                return TimeSpan.FromSeconds(timeinseconds).TotalHours.ToString();
            }
            else
            {
                return null;
            }
        }

        private int CalculateWorkingTimeInSeconds(IssuesRoot root)
        {
            int result = 0;
            for(int i = 0; i < root.issues.Count; i++)
            {
                if(root.issues[i].fields.assignee == null)
                {
                    continue;
                }
                if(root.issues[i].fields.timespent != null && root.issues[i].fields.assignee.name == UsernameTextBox.Text)
                {
                    result += (int)root.issues[i].fields.timespent;
                }
            }
            return result;
        }

        private void GetUsersButton_Click(object sender, EventArgs e)
        {
            GetConnectionHandler();
            GetAllUsers();
        }

        private void GetAllUsers()
        {
            var queryresult = connectionHandler.GetAllStudentUsers();
            if (queryresult != null)
            {
                JsonConv conv = new JsonConv();
                UserRoot decoderesult = conv.DecodeJsonToUserRoot(queryresult);
                string outputText = " ";
                for(int i = 0; i < decoderesult.users.items.Count; i++)
                {
                    if(decoderesult.users.items[i] != null)
                    {
                        outputText += decoderesult.users.items[i].displayName + " aka. " + decoderesult.users.items[i].name + "\r\n";
                        cConsole.WriteUserList(outputText);
                    }
                }
                conv = null;
            }
        }

    }
}
