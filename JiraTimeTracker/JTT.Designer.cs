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
            this.ApiTokenTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.TestButton = new System.Windows.Forms.Button();
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
            // ApiTokenTextBox
            // 
            this.ApiTokenTextBox.Location = new System.Drawing.Point(12, 38);
            this.ApiTokenTextBox.Name = "ApiTokenTextBox";
            this.ApiTokenTextBox.Size = new System.Drawing.Size(201, 20);
            this.ApiTokenTextBox.TabIndex = 1;
            this.ApiTokenTextBox.Text = "Jira API token";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(219, 12);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(181, 20);
            this.UsernameTextBox.TabIndex = 2;
            this.UsernameTextBox.Text = "Username";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(219, 38);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(181, 20);
            this.PasswordTextBox.TabIndex = 3;
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
            // JTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 546);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ApiTokenTextBox);
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
        private System.Windows.Forms.TextBox ApiTokenTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button TestButton;
    }
}

