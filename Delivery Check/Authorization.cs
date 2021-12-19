using System;
using System.Drawing;
using System.Windows.Forms;

namespace Delivery_Check
{
    public partial class Authorization : Form
    {
        private readonly User user = new User();
        private DBConnection dbCon = new DBConnection();
        public bool userAuth { get; private set; } = false;
        public bool isAdmin { get; private set; } = false;

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            // Проверка авторизован ли пользователь
            if (dbCon.CheckUser(user.GetLogin(), user.GetPassword()))
            {
                userAuth = true;
                isAdmin = dbCon.UserPrivilege(user.GetLogin(), user.GetPassword());
                this.Close();
            }
            login.Text = user.GetLogin();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {

            wrongPass.Visible = false;
            user.SetAuth(login.Text, password.Text);

            if (dbCon.CheckUser(user.GetLogin(), user.GetPassword()))
            {
                wrongPass.ForeColor = Color.Green;
                wrongPass.Text = "Вход";
                wrongPass.Visible = true;
                userAuth = true;
                isAdmin = dbCon.UserPrivilege(user.GetLogin(), user.GetPassword());
                Log.Write("Авторизация", "Вход в систему");
                this.Close();
            }
            else
            {
                wrongPass.Visible = true;
            }
        }
    }
}
