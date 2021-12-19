namespace Delivery_Check
{
    partial class Notification
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
            this.components = new System.ComponentModel.Container();
            this.message = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageTypeAlert = new System.Windows.Forms.PictureBox();
            this.imageExitButton = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageTypeAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageExitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.message.Location = new System.Drawing.Point(85, 31);
            this.message.MaximumSize = new System.Drawing.Size(270, 65);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 21);
            this.message.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageTypeAlert
            // 
            this.imageTypeAlert.Image = global::Delivery_Check.Properties.Resources.info;
            this.imageTypeAlert.Location = new System.Drawing.Point(19, 37);
            this.imageTypeAlert.Name = "imageTypeAlert";
            this.imageTypeAlert.Size = new System.Drawing.Size(60, 50);
            this.imageTypeAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageTypeAlert.TabIndex = 4;
            this.imageTypeAlert.TabStop = false;
            // 
            // imageExitButton
            // 
            this.imageExitButton.Image = global::Delivery_Check.Properties.Resources.exit;
            this.imageExitButton.Location = new System.Drawing.Point(354, 0);
            this.imageExitButton.Name = "imageExitButton";
            this.imageExitButton.Size = new System.Drawing.Size(26, 26);
            this.imageExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageExitButton.TabIndex = 5;
            this.imageExitButton.TabStop = false;
            this.imageExitButton.Click += new System.EventHandler(this.imageExitButton_Click_1);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.title.Location = new System.Drawing.Point(12, 5);
            this.title.MaximumSize = new System.Drawing.Size(340, 40);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(242, 21);
            this.title.TabIndex = 6;
            this.title.Text = "Kakoe to o4en\' vaznoe ob\'9vlenie";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(380, 95);
            this.Controls.Add(this.imageTypeAlert);
            this.Controls.Add(this.title);
            this.Controls.Add(this.imageExitButton);
            this.Controls.Add(this.message);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notification";
            ((System.ComponentModel.ISupportInitialize)(this.imageTypeAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageExitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox imageTypeAlert;
        private System.Windows.Forms.PictureBox imageExitButton;
        private System.Windows.Forms.Label title;
    }
}