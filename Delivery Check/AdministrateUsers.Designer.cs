namespace Delivery_Check
{
    partial class AdministrateUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrateUsers));
            this.userSelected = new System.Windows.Forms.ComboBox();
            this.logInfo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.Label();
            this.setPassword = new System.Windows.Forms.TextBox();
            this.saveSettings = new System.Windows.Forms.Button();
            this.showLogin = new System.Windows.Forms.Label();
            this.setLogin = new System.Windows.Forms.TextBox();
            this.showChangeUserPassword = new System.Windows.Forms.Label();
            this.setNewPasswordFromUser = new System.Windows.Forms.TextBox();
            this.deleteUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userSelected
            // 
            this.userSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userSelected.FormattingEnabled = true;
            this.userSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userSelected.Items.AddRange(new object[] {
            "Добавить пользователя"});
            this.userSelected.Location = new System.Drawing.Point(20, 35);
            this.userSelected.Name = "userSelected";
            this.userSelected.Size = new System.Drawing.Size(156, 21);
            this.userSelected.TabIndex = 0;
            this.userSelected.TabStop = false;
            this.userSelected.SelectedIndexChanged += new System.EventHandler(this.UserSelected_SelectedIndexChanged);
            // 
            // logInfo
            // 
            this.logInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logInfo.FormattingEnabled = true;
            this.logInfo.Location = new System.Drawing.Point(355, -1);
            this.logInfo.Name = "logInfo";
            this.logInfo.Size = new System.Drawing.Size(271, 407);
            this.logInfo.TabIndex = 1;
            this.logInfo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Последнии действия\r\nпользователя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выбор пользователя";
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showPassword.Location = new System.Drawing.Point(20, 149);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(156, 16);
            this.showPassword.TabIndex = 4;
            this.showPassword.Text = "Пароль пользователя:";
            // 
            // setPassword
            // 
            this.setPassword.Location = new System.Drawing.Point(20, 168);
            this.setPassword.Name = "setPassword";
            this.setPassword.Size = new System.Drawing.Size(156, 20);
            this.setPassword.TabIndex = 2;
            // 
            // saveSettings
            // 
            this.saveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveSettings.Location = new System.Drawing.Point(55, 211);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(105, 32);
            this.saveSettings.TabIndex = 3;
            this.saveSettings.Text = "Применить";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // showLogin
            // 
            this.showLogin.AutoSize = true;
            this.showLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showLogin.Location = new System.Drawing.Point(24, 86);
            this.showLogin.Name = "showLogin";
            this.showLogin.Size = new System.Drawing.Size(146, 16);
            this.showLogin.TabIndex = 7;
            this.showLogin.Text = "Логин пользователя:";
            // 
            // setLogin
            // 
            this.setLogin.Location = new System.Drawing.Point(20, 105);
            this.setLogin.Name = "setLogin";
            this.setLogin.Size = new System.Drawing.Size(156, 20);
            this.setLogin.TabIndex = 1;
            // 
            // showChangeUserPassword
            // 
            this.showChangeUserPassword.AutoSize = true;
            this.showChangeUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showChangeUserPassword.Location = new System.Drawing.Point(34, 86);
            this.showChangeUserPassword.Name = "showChangeUserPassword";
            this.showChangeUserPassword.Size = new System.Drawing.Size(126, 16);
            this.showChangeUserPassword.TabIndex = 9;
            this.showChangeUserPassword.Text = "Изменить пароль:";
            // 
            // setNewPasswordFromUser
            // 
            this.setNewPasswordFromUser.Location = new System.Drawing.Point(20, 105);
            this.setNewPasswordFromUser.Name = "setNewPasswordFromUser";
            this.setNewPasswordFromUser.Size = new System.Drawing.Size(156, 20);
            this.setNewPasswordFromUser.TabIndex = 1;
            // 
            // deleteUser
            // 
            this.deleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteUser.Location = new System.Drawing.Point(55, 249);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(105, 43);
            this.deleteUser.TabIndex = 10;
            this.deleteUser.Text = "Удалить пользователя";
            this.deleteUser.UseVisualStyleBackColor = true;
            this.deleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // AdministrateUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(625, 402);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.setNewPasswordFromUser);
            this.Controls.Add(this.showChangeUserPassword);
            this.Controls.Add(this.setLogin);
            this.Controls.Add(this.showLogin);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.setPassword);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logInfo);
            this.Controls.Add(this.userSelected);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdministrateUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование пользователей";
            this.Load += new System.EventHandler(this.AdministrateUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox userSelected;
        private System.Windows.Forms.ListBox logInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label showPassword;
        private System.Windows.Forms.TextBox setPassword;
        private System.Windows.Forms.Button saveSettings;
        private System.Windows.Forms.Label showLogin;
        private System.Windows.Forms.TextBox setLogin;
        private System.Windows.Forms.Label showChangeUserPassword;
        private System.Windows.Forms.TextBox setNewPasswordFromUser;
        private System.Windows.Forms.Button deleteUser;
    }
}