namespace JiraTimeTracker
{
    partial class JTT
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JTT));
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ProjectKeyTextBox = new System.Windows.Forms.TextBox();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.GetUsersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(12, 12);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(201, 20);
            this.UrlTextBox.TabIndex = 0;
            this.UrlTextBox.Text = "Jira URL : Port";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(219, 12);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(181, 20);
            this.LoginTextBox.TabIndex = 1;
            this.LoginTextBox.Text = "Login";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(219, 38);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(181, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Password";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(12, 511);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(101, 23);
            this.TestButton.TabIndex = 4;
            this.TestButton.Text = "Test Connection";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(12, 121);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(201, 20);
            this.UsernameTextBox.TabIndex = 4;
            this.UsernameTextBox.Text = "Jira User Username";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(12, 147);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputTextBox.Size = new System.Drawing.Size(388, 358);
            this.OutputTextBox.TabIndex = 6;
            this.OutputTextBox.Text = "Output";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(295, 511);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(105, 23);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Go!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ProjectKeyTextBox
            // 
            this.ProjectKeyTextBox.Location = new System.Drawing.Point(12, 95);
            this.ProjectKeyTextBox.Name = "ProjectKeyTextBox";
            this.ProjectKeyTextBox.Size = new System.Drawing.Size(201, 20);
            this.ProjectKeyTextBox.TabIndex = 3;
            this.ProjectKeyTextBox.Text = "Jira Project Key";
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(461, 12);
            this.UserTextBox.Multiline = true;
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.ReadOnly = true;
            this.UserTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserTextBox.Size = new System.Drawing.Size(417, 493);
            this.UserTextBox.TabIndex = 9;
            // 
            // GetUsersButton
            // 
            this.GetUsersButton.Location = new System.Drawing.Point(579, 511);
            this.GetUsersButton.Name = "GetUsersButton";
            this.GetUsersButton.Size = new System.Drawing.Size(184, 23);
            this.GetUsersButton.TabIndex = 10;
            this.GetUsersButton.Text = "Get All Jira Users in Student Group";
            this.GetUsersButton.UseVisualStyleBackColor = true;
            this.GetUsersButton.Click += new System.EventHandler(this.GetUsersButton_Click);
            // 
            // JTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 546);
            this.Controls.Add(this.GetUsersButton);
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.ProjectKeyTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.UrlTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JTT";
            this.Text = "Jira Time Tracker";
            this.Load += new System.EventHandler(this.JTT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox ProjectKeyTextBox;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Button GetUsersButton;
    }
}

