using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JiraTimeTracker
{
    public partial class JTT : Form
    {
        private ConnectionHandler connectionHandler;
        private JTT form;
        private CConsole cConsole;
        private JsonConv jsonConv;

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
            jsonConv = new JsonConv();
            cConsole = new CConsole(form.OutputTextBox, form.UserTextBox);
        }

        private ConnectionHandler GetConnectionHandler()
        {
            if(connectionHandler == null)
            {
                connectionHandler = new ConnectionHandler(UrlTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text,cConsole);
                return connectionHandler;
            }
            else
            {
                connectionHandler.UpdateVariables(UrlTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text);
                return connectionHandler;
            }
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
            GetTimeForUser();
        }

        private void GetTimeForUser()
        {
            var result = GetWorkingTime();
            if(result != null)
            {
                cConsole.WriteOutput("Working hours for user " + UsernameTextBox.Text + " : " + result);
                cConsole.WriteOutput("Operation Complete!");
            }
            else
            {
                cConsole.WriteOutput("Error: Is there a typo in the provided username/too many failed login attempts?");
            }
        }

        private string GetWorkingTime()
        {
            var queryresult = GetConnectionHandler().GetAssignedIssuesForUser(UsernameTextBox.Text,ProjectKeyTextBox.Text);
            cConsole.WriteOutput("Parsing Response, please wait...");
            if (queryresult != null)
            {
                IssuesRoot decoderesult =  jsonConv.DecodeJsonToIssuesRoot(queryresult);
                int timeinseconds = CalculateWorkingTimeInSeconds(decoderesult);
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
                UserRoot decoderesult = jsonConv.DecodeJsonToUserRoot(queryresult);
                string outputText = " ";
                for(int i = 0; i < decoderesult.users.items.Count; i++)
                {
                    if(decoderesult.users.items[i] != null)
                    {
                        outputText += decoderesult.users.items[i].displayName + " aka. " + decoderesult.users.items[i].name + "\r\n";
                        
                    }
                }
                cConsole.WriteUserList(outputText);
                cConsole.WriteOutput("Operation Complete!");
            }
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            CheckForConfig();
        }

        private bool CheckForConfig()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/conf.cfg"))
            {
                cConsole.WriteOutput("Config found! Loading...");
                string configstring = File.ReadAllText(Directory.GetCurrentDirectory() + "/conf.cfg", Encoding.UTF8);
                Config conf =  jsonConv.DecodeJsonToConfig(configstring);
                try
                {
                    if (conf.login != null)
                    {
                        LoginTextBox.Text = conf.login;
                    }
                    if (conf.url != null)
                    {
                        UrlTextBox.Text = conf.url;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    cConsole.WriteOutput("Error: Config is in non-supported format.");
                    return false;
                }
                
            }
            else
            {
                cConsole.WriteOutput("Error: No config found");
                return false;
            }
        }

    }
}
