using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Delivery_Check
{
    public partial class OrderForm : Form {    
        public OrderForm()
        {
            InitializeComponent();

            date.MinDate = DateTime.Now.AddDays(1);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if(description.Text.Length != 0)
            {
                DBConnection dbCon = new DBConnection();
                dbCon.IsConnect();
                string queryCheckTable = $"SHOW TABLES LIKE '{GetTime()}'";
                MySqlCommand cmd = new MySqlCommand(queryCheckTable, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                try
                {
                    reader.GetString(0);
                    reader.Close();
                }
                catch
                {
                    string queryCreateTable = $"CREATE TABLE `{GetTime()}`(`id` INT(4) NOT NULL AUTO_INCREMENT,`code` INT(4) NOT NULL,`order_time` VARCHAR(5) NOT NULL,`step` VARCHAR(5) NOT NULL,`addr_phone` TEXT NOT NULL,`can_delivered` VARCHAR(5) NOT NULL,`courier_received` VARCHAR(200) NULL DEFAULT '',`courier_gave` VARCHAR(5) NULL DEFAULT '', `last` VARCHAR(5) NULL DEFAULT '', `description` TEXT NOT NULL DEFAULT '', `deleted` BOOLEAN NOT NULL DEFAULT FALSE, `delivery` BOOLEAN NOT NULL DEFAULT TRUE, PRIMARY KEY(`id`)) ENGINE = InnoDB;";
                    reader.Close();
                    cmd = new MySqlCommand(queryCreateTable, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                }
                string queryInsertOrder = $"INSERT INTO `{GetTime()}` (`id`, `code`, `order_time`, `step`, `addr_phone`, `can_delivered`, `description`, `delivery`) VALUES (NULL, '0', '00:00', '00:00', '+7', '00:00', '{description.Text}', '1');";
                cmd = new MySqlCommand(queryInsertOrder, dbCon.Connection);
                cmd.ExecuteNonQuery();
                dbCon.Close();
                this.Close();
                Log.Write("CREATE", $"Создание предзаказа на дату {date.Value:dd.MM.yyyy}");
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Success, $"Создание предзаказа на дату {date.Value:dd.MM.yyyy}", "Предзаказ");
            }
            else
            {
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Error, "Введите корректное описание!", "Ошибка");
            }
        }
        private string GetTime()
        {
            return "orders_" + date.Value.ToString("dd.MM.yyyy");
        }
    }
}
