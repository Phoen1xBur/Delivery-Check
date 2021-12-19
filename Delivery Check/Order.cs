using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Delivery_Check
{
    class Order
    {
        private readonly byte id;
        private readonly byte code;
        private readonly DateTime orderTime;
        private readonly string step;
        private readonly string addrPhone;
        private readonly DateTimePicker timePicker;

        public DateTime CanDelivered { get; set; }
        public DateTime CourierGave { get; set; }
        public string CourierReceived { get; set; }
        public string Last { get; set; }
        public string Description { get; set; }
        public byte isDelivery { get; }
        public byte CountPrinted = 0;

        public Order(DateTimePicker timePicker)
        {
            id = 0;
            code = 0;
            orderTime = DateTime.MinValue;
            CanDelivered = DateTime.MinValue;
            CourierReceived = "";
            CourierGave = DateTime.MinValue;
            step = "";
            addrPhone = "";
            Last = "-";
            Description = "";
            isDelivery = GridFilterName.delivery;
            this.timePicker = timePicker;
        }
        public Order(DateTimePicker timePicker, byte id, byte code, DateTime orderTime, string step, string addrPhone, DateTime canDelivered, string courierReceived, DateTime courierGave, string last, string description, byte isDelivery)
        {
            this.id = id;
            this.code = code;
            this.orderTime = orderTime;
            this.CanDelivered = canDelivered;
            this.CourierReceived = courierReceived;
            this.CourierGave = courierGave;
            this.step = step;
            this.addrPhone = addrPhone;
            this.Last = last;
            this.Description = description;
            this.timePicker = timePicker;
            this.isDelivery = isDelivery;
        }
        public void PutInTable(DataGridViewRow grid)
        {
            grid.Cells[GridColumnName.code].Value = code;
            grid.Cells[GridColumnName.orderTime].Value = orderTime.ToString("HH:mm");
            grid.Cells[GridColumnName.step].Value = step;
            grid.Cells[GridColumnName.addrPhone].Value = addrPhone;
            grid.Cells[GridColumnName.courerReceived].Value = CourierReceived;
            grid.Cells[GridColumnName.courerGave].Value = (IsTimeZero(CourierGave)) ? "" : CourierGave.ToString("HH:mm");
            grid.Cells[GridColumnName.canDelivered].Value = CanDelivered.ToString("HH:mm");
            grid.Cells[GridColumnName.last].Value = Last;
            grid.Cells[GridColumnName.description].Value = Description;
        }
        public bool IsItCode(byte code)
        {
            return (this.code == code);
        }
        public byte GetCode()
        {
            return code;
        }
        public string GetPhone()
        {
            return addrPhone;
        }
        public void DBUpdateCourierGave(DateTime courierGaveTime, DBConnection dbCon)
        {
            CourierGave = courierGaveTime;

            string query = $"UPDATE `{GetTimeNow()}` SET `courier_gave` = '{CourierGave:HH:mm}' WHERE `{GetTimeNow()}`.`id` = {id};";

            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            cmd.ExecuteNonQuery();
        }
        public void DBUpdateCourierReceived(string courierReceivedTime, DBConnection dbCon)
        {
            CourierReceived = courierReceivedTime;

            string query = $"UPDATE `{GetTimeNow()}` SET `courier_received` = '{courierReceivedTime}' WHERE `{GetTimeNow()}`.`id` = {id};";

            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            cmd.ExecuteNonQuery();
        }
        public void DBUpdateCanDelivery(DateTime canDeliveredTime, DBConnection dbCon)
        {
            CanDelivered = canDeliveredTime;

            string query = $"UPDATE `{GetTimeNow()}` SET `can_delivered` = '{CanDelivered:HH:mm}' WHERE `{GetTimeNow()}`.`id` = {id};";

            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            cmd.ExecuteNonQuery();
        }
        public void DBUpdateLast(string lastStr, DBConnection dbCon)
        {
            Last = lastStr;

            string query = $"UPDATE `{GetTimeNow()}` SET `last` = '{lastStr}' WHERE `{GetTimeNow()}`.`id` = {id};";

            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            cmd.ExecuteNonQuery();
        }
        public void DBUpdateDescription(string desc, DBConnection dbCon)
        {
            Description = desc;

            string query = $"UPDATE `{GetTimeNow()}` SET `description` = '{Description}' WHERE `{GetTimeNow()}`.`id` = {id};";

            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            cmd.ExecuteNonQuery();
        }
        public void DBUpdateDeleted(bool deleted, DBConnection dbCon)
        {
            string deletedSting;
            if (deleted) deletedSting = "1"; else deletedSting = "0";
            string query = $"UPDATE `{GetTimeNow()}` SET `deleted` = '{deletedSting}' WHERE `{GetTimeNow()}`.`id` = {id};";

            MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
            cmd.ExecuteNonQuery();
        }
        private string GetTimeNow()
        {
            return "orders_" + timePicker.Value.ToString("dd.MM.yyyy");
        }
        private bool IsTimeZero(DateTime time)
        {
            return time.ToString("hhmm") == DateTime.MinValue.ToString("hhmm");
        }
    }
}
public static class DBOrder
{
    public const byte Id = 0;
    public const byte Code = 1;
    public const byte OrderTime = 2;
    public const byte Step = 3;
    public const byte AddrPhone = 4;
    public const byte CanDelivered = 5;
    public const byte CourierReceived = 6;
    public const byte CourierGave = 7;
    public const byte Last = 8;
    public const byte Description = 9;
    public const byte Deleted = 10;
    public const byte isDelivery = 11;
}
public static class GridColumnName
{
    public static byte code = 0;
    public static byte orderTime = 1;
    public static byte step = 2;
    public static byte addrPhone = 3;
    public static byte courerReceived = 4;
    public static byte courerGave = 5;
    public static byte canDelivered = 6;
    public static byte last = 7;
    public static byte description = 8;
}
public static class GridFilterName
{
    public static byte delivery = 0;
    public static byte noDelivery = 1;
    public static byte all = 2;
}