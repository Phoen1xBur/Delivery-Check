using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_Check
{
    public partial class ChangerPasswordUser : Form
    {
        private readonly User user = new User();
        private DBConnection dbCon = new DBConnection();
        public ChangerPasswordUser()
        {
            InitializeComponent();
        }

        private void ChangerUser_Load(object sender, EventArgs e)
        {
            login.Text = user.GetLogin();
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            if(lastPassword.Text != user.GetPassword())
            {
                wrongPass.Visible = true;
                return;
            }
            dbCon.ChangePasswordFromUser(user.GetLogin(), newPassword.Text);
            Log.Write("CHANGE", "Смена пароля");
            Application.Exit();
        }
    }
}
