using System;
using System.Drawing;
using System.Windows.Forms;

namespace Delivery_Check
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }

        int x, y;
        
        private byte action = AlertAction.Start;

        public void SetAlert(byte alertType, String message, String title="Объявление")
        {
            this.Opacity = 0;
            this.StartPosition = FormStartPosition.Manual;

            string formName;
            formName = $"Alert";
            FormCollection allForms = Application.OpenForms;
            int count = 1;
            foreach (Form form in allForms)
            {
                if (form.Text.StartsWith("Notification"))
                {
                    count++;
                }
            }
            this.Name = formName;
            x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * count - 5 * count;
            this.Location = new Point(x, y);
            switch (alertType)
            {
                default:
                case AlertType.Info:
                    this.imageTypeAlert.Image = Properties.Resources.info;
                    this.BackColor = Color.FromArgb(71, 169, 248);
                    break;
                case AlertType.Success:
                    this.imageTypeAlert.Image = Properties.Resources.info;
                    this.BackColor = Color.FromArgb(42, 171, 160);
                    break;
                case AlertType.Warning:
                    this.imageTypeAlert.Image = Properties.Resources.warn;
                    this.BackColor = Color.FromArgb(255, 179, 2);
                    break;
                case AlertType.Error:
                    this.imageTypeAlert.Image = Properties.Resources.cancel;
                    this.BackColor = Color.FromArgb(255, 121, 70);
                    break;
            }
            this.message.Text = message;
            this.title.Text = title;
            Show();
            timer1.Interval = 1;
            timer1.Start();
        }
        private void imageExitButton_Click_1(object sender, EventArgs e)
        {
            this.timer1.Interval = 1;
            action = AlertAction.Close;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (action)
            {
                default:
                case AlertAction.Start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (x < this.Location.X){
                        this.Left -= 1;
                    }
                    else
                    {
                        if (this.Opacity == 1)
                        {
                            action = AlertAction.Wait;
                        }
                    }
                    break;
                case AlertAction.Wait:
                    timer1.Interval = 5000;
                    action = AlertAction.Close;
                    break;
                case AlertAction.Close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (this.Opacity == 0){
                        Close();
                    }
                    break;
            }
        }
    }

    public static class AlertType
    {
        public const byte Success = 0;
        public const byte Warning = 1;
        public const byte Error = 2;
        public const byte Info = 3;
    }
}
