namespace Delivery_Check
{
    partial class ChangerPasswordUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.lastPassword = new System.Windows.Forms.TextBox();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.changePass = new System.Windows.Forms.Button();
            this.wrongPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(76, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваш логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Старый\r\nпароль:";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(58, 36);
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Size = new System.Drawing.Size(138, 20);
            this.login.TabIndex = 2;
            this.login.TabStop = false;
            // 
            // lastPassword
            // 
            this.lastPassword.Location = new System.Drawing.Point(101, 84);
            this.lastPassword.Name = "lastPassword";
            this.lastPassword.Size = new System.Drawing.Size(138, 20);
            this.lastPassword.TabIndex = 1;
            // 
            // newPassword
            // 
            this.newPassword.Location = new System.Drawing.Point(101, 125);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(138, 20);
            this.newPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-1, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Новый пароль:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // changePass
            // 
            this.changePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePass.Location = new System.Drawing.Point(80, 195);
            this.changePass.Name = "changePass";
            this.changePass.Size = new System.Drawing.Size(90, 45);
            this.changePass.TabIndex = 3;
            this.changePass.Text = "Применить\r\nизменения";
            this.changePass.UseVisualStyleBackColor = true;
            this.changePass.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // wrongPass
            // 
            this.wrongPass.AutoSize = true;
            this.wrongPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wrongPass.ForeColor = System.Drawing.Color.Red;
            this.wrongPass.Location = new System.Drawing.Point(65, 162);
            this.wrongPass.Name = "wrongPass";
            this.wrongPass.Size = new System.Drawing.Size(131, 16);
            this.wrongPass.TabIndex = 5;
            this.wrongPass.Text = "Не верный пароль!";
            this.wrongPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wrongPass.Visible = false;
            // 
            // ChangerUser
            // 
            this.AcceptButton = this.changePass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(259, 261);
            this.Controls.Add(this.wrongPass);
            this.Controls.Add(this.changePass);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastPassword);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangerUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление пользователем";
            this.Load += new System.EventHandler(this.ChangerUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox lastPassword;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button changePass;
        private System.Windows.Forms.Label wrongPass;
    }
}