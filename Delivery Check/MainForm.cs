using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Delivery_Check
{
    public partial class MainForm : Form
    {
        private DateTime counterForCheckUpdateDB = DateTime.Now;private DateTime timeInterval = DateTime.Now;
        private DBConnection dbCon = new DBConnection();
        private Order[] allOrders;
        private byte filter = GridFilterName.all;
        private List<string> OrgIds;

        private readonly ColorTable colorTable = new ColorTable();
        private readonly bool isAdmin;

        public MainForm(bool isAdmin)
        {
         this.isAdmin = isAdmin;
         InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
         // Проверка наличия обновлений
         CheckUpdates();

         // Делаем фильтр по умолчанию
         filterBox.SelectedIndex = GridFilterName.delivery;
         filterOrgId.SelectedIndex = 0; // Default - all
         OrgIds = dbCon.GetOrganizationIds();
         foreach (string orgName in dbCon.GetOrganizationNames())
         {
            filterOrgId.Items.Add(orgName);
         }

         // Обновляем таблицу (показываем заказы относительно фильтра)
         //UpdateGrid(); // Automatic reloaded

         // Делаем задний фон кнопок соответствующим цветом
         btnSucceeded.BackColor = colorTable.Succeeded;
         btnLatecomer.BackColor = colorTable.Latecomer;

         if (isAdmin)
         {
               ToolStripMenuItem item = new ToolStripMenuItem("Администрирование");
               ToolStripMenuItem subMenu = new ToolStripMenuItem("Редактирование пользователей");
               item.DropDownItems.Add(subMenu);
               subMenu.Click += new EventHandler(EditUsers);
               func.DropDownItems.Add(item);
         }
        }
        private void EditUsers(object sender, EventArgs e)
        {
            new AdministrateUsers().Show();
        }

        private void CheckUpdates()
        {
            string myVersion = Application.ProductVersion.ToString();
            //string actualVersion = GetActualVersion();
            string actualVersion = myVersion;
            if (actualVersion != myVersion)
            {
                DialogResult result = MessageBox.Show("Доступно обновление\nСкачать?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string target = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\DCSetup.exe";
                        using (var client = new WebClient())
                        {
                            Console.WriteLine(Environment.SpecialFolder.CommonDocuments.ToString());
                            //string target = Directory.GetCurrentDirectory() + "/DCSetup.exe";
                            client.DownloadFile("http://82.146.45.177/DCSetup.exe", target);
                        }
                        Process.Start(target);
                        Application.Exit();
                    }
                    catch
                    {
                        Notification notification = new Notification();
                        notification.SetAlert(AlertType.Error, "Невозможно скачать обновление.Отказано в доступе.\nПерезапустите приложение с правами Администратора", "Ошибка");
                        //new Message("Ошибка", "Невозможно скачать обновление. Отказано в доступе.\nПерезапустите приложение с правами Администратора").Show(MessageIcons.Error);
                        MessageBox.Show("Невозможно скачать обновление. Отказано в доступе.\nПерезапустите приложение с правами Администратора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                {
                    Notification notification = new Notification();
                    notification.SetAlert(AlertType.Warning, "Обновление не обязательно, но желательно!", "Внимание");
                    //new Message("Внимание", "Обновление не обязательно, но желательно!").Show(MessageIcons.Warning);
                }
            }
        }
        private string GetActualVersion()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://82.146.45.177/version");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream;
                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data.Trim();

        }
        private void UpdateGrid()
        {
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;

            dbCon = new DBConnection();
            
            if (!dbCon.IsConnect()) return;

            allOrders = GetAllOrders();
            UpdateValueAllTable();

            SortedGrid();
            grid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        }
        private void UpdateValueAllTable()
        {
         DateTime timeMagnitka = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
         DateTime.UtcNow, "Russian Standard Time").AddHours(2);

         for (int i = 0; i < allOrders.Length; i++)
         {
            Order order = allOrders[i];
            if (order == null) continue;
            if (filter == GridFilterName.all || order.isDelivery == filter)
            {
               if (!CheckOrderInTable(order.GetCode(), order.Description))
               {
                  // Проверка откуда заказ (какая точка)
                  if (filterOrgId.SelectedIndex > 0)
                  {
                     // Фильтр не на все точки. Добавляем заказы только с выбранных точек
                     if (OrgIds[filterOrgId.SelectedIndex - 1] != order.OrgId)
                     {
                        continue;
                     }
                  }
                  grid.Rows.Add();
                  int rowsCount = grid.Rows.Count - 1;
                  order.PutInTable(grid.Rows[rowsCount]);
                  UpdateColor(grid.Rows[rowsCount]);
               }
            }

            if ((filter == GridFilterName.all || order.isDelivery == filter) &&
               order.CourierReceived == "" && order.CourierGave == DateTime.MinValue &&
               order.CanDelivered.ToString("HH:mm") != "00:00" &&
               TimeSpan.Zero <= order.CanDelivered.Subtract(timeMagnitka) &&
               order.CanDelivered.Subtract(timeMagnitka) <= TimeSpan.Zero.Add(TimeSpan.FromMinutes(20)))
            {
               //new Message($"Заказ № {order.GetCode()}", "Срок жизни заказа скоро/уже закончился! Уточните у курьера о его доставке.").Show(MessageIcons.Warning);

               Notification notification = new Notification();
               notification.SetAlert(AlertType.Warning, "Заказ скоро сгорит! Уточните у курьера о его доставке. Осталось менее 20 мин.", $"Заказ № {order.GetCode()}");
            }
         }
        }
        private bool CheckOrderInTable(int codeOrder, string description)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (codeOrder == 0)
                {
                    if (grid[GridColumnName.description, i].Value.ToString() == description) return true;
                }
                else
                {
                    if ((int)grid[GridColumnName.code, i].Value == codeOrder) return true;
                }
            }
            return false;
        }
        private Order[] GetAllOrders()
        {
            dbCon.IsConnect();
            Order[] orders;
            MySqlDataReader reader;
            try
            {
                reader = GetOrders();
            }
            catch (MySqlException)
            {
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Warning, "На этот день, заказов нет!", "Внимание");
                //new Message("Внимание", "На этот день, заказов нет!").Show(MessageIcons.Warning);
                //MessageBox.Show("На этот день, заказов нет!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                orders = new Order[1];
                orders[0] = new Order(setDateDialog);
                return orders;
            }
            int j = 0;
            reader.Read();
            try
            {
                orders = new Order[reader.GetInt32(DBOrder.Id)];
            }catch(MySqlException)
            {
                reader.Close();
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Warning, "На этот день, заказов нет!", "Внимание");
                //new Message("Внимание", "На данный момент, заказов нет!").Show(MessageIcons.Info);
                //MessageBox.Show("На данный момент, заказов нет!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                orders = new Order[1];
                orders[0] = new Order(setDateDialog);
                return orders;
            }
            do
            {
                bool isDeleted = reader.GetBoolean(DBOrder.Deleted);

                if (isDeleted)
                {
                    continue;
                }
                string stepStr = reader.GetString(DBOrder.Step);
                string canDeliveredStr = reader.GetString(DBOrder.CanDelivered);
                string courierReceivedStr = GetCourier(reader, DBOrder.CourierReceived);
                string courierGaveStr = GetCourier(reader, DBOrder.CourierGave);
                string last = reader.GetString(DBOrder.Last);
                string desc = reader.GetString(DBOrder.Description);
                DateTime order_time = DateTime.Parse(reader.GetString(DBOrder.OrderTime));
                byte isDelivery = reader.GetBoolean(DBOrder.isDelivery) ? (byte) 0 : (byte) 1;
                string step = "00:00";
                if (stepStr != "ERROR")
                {
                    step = reader.GetString(DBOrder.Step);
                }
                DateTime canDelivered = (canDeliveredStr == "ERROR") ? DateTime.MinValue : DateTime.Parse(canDeliveredStr);
                DateTime courierGave = (courierGaveStr == "") ? DateTime.MinValue : DateTime.Parse(courierGaveStr);
                string orgId = reader.GetString(DBOrder.OrgId);

                orders[j] = new Order(
                    setDateDialog,
                    reader.GetInt32(DBOrder.Id),
                    reader.GetInt32(DBOrder.Code),
                    order_time, step,
                    reader.GetString(DBOrder.AddrPhone),
                    canDelivered, courierReceivedStr,
                    courierGave, last, desc, orgId, isDelivery);
                j++;
            } while (reader.Read());
            reader.Close();
            dbCon.Close();
            return orders;
        }
        #region Another Functions
        private void SortedGrid()
        {
            if (grid.SortedColumn != null) grid.Sort(grid.SortedColumn, GetSortDirection(grid.SortOrder));
            else grid.Sort(grid.Columns[GridColumnName.code], GetSortDirection(grid.SortOrder));
        }
        private ListSortDirection GetSortDirection(System.Windows.Forms.SortOrder sortOrder)
        {
            if (sortOrder == System.Windows.Forms.SortOrder.Ascending) return ListSortDirection.Ascending;
            else return ListSortDirection.Descending;
        }
        private string GetCourier(MySqlDataReader reader, byte courer)
        {
            string data;
            try
            {
                data = reader.GetString(courer);
            }
            catch
            {
                data = "";
            }
            return data;
        }
        private MySqlDataReader GetOrders()
        {
            string query = $"SELECT * FROM `{GetTimeNow()}` ORDER BY `id` DESC";
            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            return cmd.ExecuteReader();
        }
        private string GetTimeNow()
        {
            return "orders_" + setDateDialog.Value.ToString("dd.MM.yyyy");
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeInterval = timeInterval.AddSeconds(1);
            TimeSpan time_interval = (counterForCheckUpdateDB - timeInterval) + TimeSpan.FromMinutes(1.5);
            toolStripLabel1.Text = time_interval.ToString(@"m\:ss");
            if(time_interval <= TimeSpan.Zero)
            {
                counterForCheckUpdateDB = DateTime.Now;
                timeInterval = DateTime.Now;
                UpdateGrid();
            }
        }
        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dbCon.IsConnect();

            DataGridViewCell cell = grid[e.ColumnIndex, e.RowIndex];
            if (e.ColumnIndex == GridColumnName.courerReceived)
            {
                string courierReceivedTime = cell.Value.ToString();
                
                int code = (int)grid[GridColumnName.code, e.RowIndex].Value;
                Order order = GetOrderByCode(code);
                order.DBUpdateCourierReceived(courierReceivedTime, dbCon);
                Log.Write("UPDATE", $"Заказ № {order.GetCode()} | Курьер взял = {courierReceivedTime}");
            }
            else if (e.ColumnIndex == GridColumnName.courerGave)
            {
                if (cell.Value.ToString() == "")
                {
                    int code = (int)grid[GridColumnName.code, e.RowIndex].Value;
                    Order order = GetOrderByCode(code);
                    order.DBUpdateCourierGave(DateTime.MinValue, dbCon);

                    grid[GridColumnName.last, e.RowIndex].Value = "";
                    order.DBUpdateLast("", dbCon);
                    Log.Write("UPDATE", $"Заказ № {order.GetCode()} | Курьер отдал = [Удаленно]");
                }
                else if (cell.Value.ToString().Length != 5)
                {
                    MessageBox.Show("Введите корректное время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        DateTime.Parse(cell.Value.ToString());
                    }
                    catch
                    {
                        cell.Value = "";
                        return;
                    }

                    UpdateLast(e);
                    DateTime courierGaveTime = DateTime.Parse(cell.Value.ToString());

                    int code = (int)grid[GridColumnName.code, e.RowIndex].Value;
                    Order order = GetOrderByCode(code);
                    order.DBUpdateCourierGave(courierGaveTime, dbCon);
                    Log.Write("UPDATE", $"Заказ № {order.GetCode()} | Курьер отдал = {courierGaveTime:HH:mm}");
                }
                
            }
            else if (e.ColumnIndex == GridColumnName.canDelivered)
            {
                if (cell.Value == null)
                {
                    MessageBox.Show("Введите корректное время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (cell.Value.ToString().Length != 5)
                {
                    MessageBox.Show("Введите корректное время!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        DateTime.Parse(cell.Value.ToString());
                    }
                    catch
                    {
                        cell.Value = "";
                        return;
                    }

                    UpdateLast(e);

                    int code = (int)grid[GridColumnName.code, e.RowIndex].Value;
                    Order order = GetOrderByCode(code);
                    DateTime canDeliveredTime = DateTime.Parse(cell.Value.ToString());
                    order.DBUpdateCanDelivery(canDeliveredTime, dbCon);
                    Log.Write("UPDATE", $"Заказ № {order.GetCode()} | Должны привезти = {canDeliveredTime:HH:mm}");
                }
            }
            else if (e.ColumnIndex == GridColumnName.description)
            {
                string desc = (cell.Value == null) ? "" : cell.Value.ToString();

                int code = (int)grid[GridColumnName.code, e.RowIndex].Value;
                Order order = GetOrderByCode(code);
                order.DBUpdateDescription(desc, dbCon);
                Log.Write("UPDATE", $"Заказ № {order.GetCode()} | Описание = {desc}");
            }

            DataGridViewRow row = grid.Rows[e.RowIndex];
            UpdateColor(row);

            timer.Enabled = true;
            toolBtnCheckUpdatedGrid.Enabled = true;
            toolBtnCheckUpdatedNewOrder.Enabled = true;
        }
        private void Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            timer.Enabled = false;
            toolBtnCheckUpdatedGrid.Enabled = false;
            toolBtnCheckUpdatedNewOrder.Enabled = false;
        }
        private Order GetOrderByCode(int code)
        {
            foreach (Order order in allOrders)
            {
                if (order.IsItCode(code))
                {
                    return order;
                }
            }
            throw new InvalidOperationException($"Указан неверный номер заказа. №: {code}");
        }
        private void UpdateLast(DataGridViewCellEventArgs e)
        {
            Order order = GetOrderByCode((int)grid[GridColumnName.code, e.RowIndex].Value);
            DataGridViewCell last = grid[GridColumnName.last, e.RowIndex];
            TimeSpan time;
            try
            {
                time = GetLastTime(e.RowIndex);
            }
            catch
            {
                return;
            }
            
            char ch = (time >= TimeSpan.Zero) ? '+' : '-';
            last.Value = ch + time.ToString(@"h\:mm");
            order.DBUpdateLast(last.Value.ToString(), dbCon);
        }
        private TimeSpan GetLastTime(int row)
        {
            DataGridViewCell courierGave = grid[GridColumnName.courerGave, row];
            DataGridViewCell canDelivered = grid[GridColumnName.canDelivered, row];
            if (courierGave.Value.ToString() == "" || canDelivered.Value.ToString() == "") throw new ArgumentNullException("courierGave or canDelivered", "Variable can'not be null");
            DateTime courierGaveTime = DateTime.Parse(courierGave.Value.ToString());
            DateTime canDeliveredTime = DateTime.Parse(canDelivered.Value.ToString());
            return (canDeliveredTime - courierGaveTime);
        }
        private void SetRowWhite(DataGridViewRow row)
        {
            SetRowColor(row, System.Drawing.Color.White);
        }
        private void SetRowColor(DataGridViewRow row, System.Drawing.Color color)
        {
            row.DefaultCellStyle.BackColor = color;
        }
        private void UpdateColor(DataGridViewRow row)
        {
            var last = row.Cells[GridColumnName.last].Value;
            if (last.ToString() == "")
            {
                SetRowWhite(row);
            }
            else if(last.ToString()[0] == '+')
            {
                SetRowColor(row, colorTable.Succeeded);
            }
            else { SetRowColor(row, colorTable.Latecomer); }
        }
        private void UpdateAllColor()
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                UpdateColor(grid.Rows[i]);
            }
        }
        private void BtnSucceeded_Click(object sender, EventArgs e)
        {
            colorTable.SetSucceeded(UpdateButtonColor(colorTable.Succeeded));
            btnSucceeded.BackColor = colorTable.Succeeded;

            UpdateAllColor();
        }
        private void BtnLatecomer_Click(object sender, EventArgs e)
        {
            colorTable.SetLatecomer(UpdateButtonColor(colorTable.Latecomer));
            btnLatecomer.BackColor = colorTable.Latecomer;

            UpdateAllColor();
        }
        private System.Drawing.Color UpdateButtonColor(System.Drawing.Color btnColor)
        {
            ColorDialog colorDialog = new ColorDialog
            {
                FullOpen = true,
                Color = btnColor
            };

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return btnColor;

            return colorDialog.Color;
        }
        #endregion
        private void SetDateDialog_ValueChanged(object sender, EventArgs e)
        {
            grid.Rows.Clear();
            UpdateGrid();
        }

        private void Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewCellCollection cell = e.Row.Cells;
            string cellAddrPhone = cell[GridColumnName.addrPhone].Value.ToString();
            if (cellAddrPhone.Length > 45) cellAddrPhone = cellAddrPhone.Substring(0, 45) + "...";
            DialogResult result = MessageBox.Show(
                $"Вы уверенны, что хотите удалить заказ с номером: {cell[GridColumnName.code].Value}?" +
                $";\n{cellAddrPhone}",
                "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No) { e.Cancel = true; return; }
            // set deleted in db
            Order order = GetOrderByCode((int)cell[GridColumnName.code].Value);
            try
            {
                dbCon.IsConnect();
                order.DBUpdateDeleted(true, dbCon);
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Info, $"Заказ №{order.GetCode()} успешно удален.", "Уведомление");
                //new Message("Уведомление", $"Заказ №{order.GetCode()} успешно удален.").Show(MessageIcons.Info);
                Log.Write("DELETE", $"Удаление заказа № {order.GetCode()}");
            }
            catch {
                Notification notification = new Notification();
                notification.SetAlert(AlertType.Error, $"Не получилось удалить заказ  №{order.GetCode()}", "Ошибка");
                //new Message("Ошибка", $"Не получилось удалить заказ  №{order.GetCode()}").Show(MessageIcons.Error);
            }
        }
        private void ToolBtnCheckUpdatedGrid_Click(object sender, EventArgs e)
        {
            grid.Rows.Clear();
            UpdateGrid();
        }
        private void ToolBtnCheckUpdatedNewOrder_Click(object sender, EventArgs e)
        {
            counterForCheckUpdateDB = DateTime.Now;
            timeInterval = DateTime.Now;
            UpdateGrid();
        }

      private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
         string searchType = sender.ToString().Split(',')[0];
         filter = searchType switch
         {
            "Все" => GridFilterName.all,
            "Самовывозы" => GridFilterName.noDelivery,
            _ => GridFilterName.delivery,
         };
         grid.Rows.Clear();
         UpdateGrid();
      }
      private void filterOrg_SelectedIndexChanged(object sender, EventArgs e)
      {
         grid.Rows.Clear();
         UpdateGrid();
      }

      private void CreateOrder_Click(object sender, EventArgs e)
        {
            _ = new OrderForm().ShowDialog();
        }

        private void ChangerPasswordUser_Click(object sender, EventArgs e)
        {
            _ = new ChangerPasswordUser().ShowDialog();
        }
    }
}
