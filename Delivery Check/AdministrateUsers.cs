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
    public partial class AdministrateUsers : Form
    {
        private DBConnection dbCon = new DBConnection();
        private User user = new User();

        public AdministrateUsers()
        {
            InitializeComponent();
        }

        private void AdministrateUsers_Load(object sender, EventArgs e)
        {
            UpdateUserSelected();
        }

        private void UpdateUserSelected()
        {
            userSelected.Items.Clear();
            userSelected.Items.Add("Добавить пользователя");
            List<string> users = dbCon.GetUsers();
            foreach (string user in users)
            {
                userSelected.Items.Add(user);
            }
            userSelected.SelectedIndex = 0;
        }
        private void UserSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCreateUser = (userSelected.SelectedIndex == 0);

            showLogin.Visible = isCreateUser;
            showPassword.Visible = isCreateUser;
            setLogin.Visible = isCreateUser;
            setPassword.Visible = isCreateUser;

            showChangeUserPassword.Visible = !isCreateUser;
            setNewPasswordFromUser.Visible = !isCreateUser;

            logInfo.Items.Clear();
            if (isCreateUser)
            {
                logInfo.Items.Add("Nothing.");
            }
            else
            {
                string userName = userSelected.Items[userSelected.SelectedIndex].ToString();
                List<string[]> logs = dbCon.GetLogsUser(userName);
                foreach (string[] log in logs)
                {
                    logInfo.Items.Add(log[0] + " | " + log[1] + " | " + log[2]);
                }
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            // is Create User?
            if (userSelected.SelectedIndex == 0)
            {
                dbCon.CreateUser(setLogin.Text, setPassword.Text);
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Success, $"Пользователь {setLogin.Text} успешно создан", "Успешно");
                Log.Write("CREATE", $"Создание пользователя {setLogin.Text}");
            }
            else
            {
                string userName = userSelected.Items[userSelected.SelectedIndex].ToString();
                dbCon.ChangePasswordFromUser(userName, setNewPasswordFromUser.Text);
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Success, $"Пароль для пользователя {userName} успешно обновлен!", "Успешно");
                Log.Write("UPDATE", $"Обновление пароля пользователя {userName}");
            }
            UpdateUserSelected();
        }
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (userSelected.SelectedIndex == 0)
            {

                Notification notification = new Notification();
                notification.SetAlert(AlertType.Error, "Выберите пользователя которого хотите удалить", "Ошибка");
            }
            else
            {
                string userName = userSelected.Items[userSelected.SelectedIndex].ToString();
                dbCon.DeleteUser(userName);
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Success, $"Пользователь {userName} успешно удален", "Успешно");
                Log.Write("DELETE", $"Удаление пользователя {userName}");
            }
        }
    }
}
