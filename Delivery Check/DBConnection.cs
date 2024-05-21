using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Delivery_Check
{
    class DBConnection
    {
        public DBConnection()
        {
        }

        public MySqlConnection Connection { get; set; }

        public bool IsConnect()
        {
            Connection = new MySqlConnection(MyEncrypt.Decrypt(Properties.Settings.Default.whatIsIt, Properties.Settings.Default.toIsIt));
            Connection.Open();
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
        public bool CheckUser(string login, String password)
        {
            IsConnect();
            string query = $"SELECT * FROM `idealist-users` WHERE `login` = '{login}' AND `password` = '{password}' AND `deleted` = '0'";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool result = reader.HasRows;
            reader.Close();
            Close();
            return result;
        }

        internal void ChangePasswordFromUser(string login, string newPass)
        {
            IsConnect();
            string query = $"UPDATE `idealist-users` SET `password` = '{newPass}' WHERE `login` = '{login}'";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            Close();
        }

        internal bool UserPrivilege(string login, string password)
        {
            IsConnect();
            string query = $"SELECT `isAdmin` FROM `idealist-users` WHERE `login` = '{login}' AND `password` = '{password}'";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bool result = reader.GetBoolean("isAdmin");
            reader.Close();
            Close();
            return result;
        }
        internal void CreateUser(string login, string pass)
        {
            IsConnect();
            string query = $"INSERT INTO `idealist-users` (`login`, `password`) VALUES ('{login}', '{pass}')";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            Close();
        }
        internal void DeleteUser(string login)
        {
            IsConnect();
            string query = $"UPDATE `idealist-users` SET `deleted` = '1' WHERE `login` = '{login}'";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            Close();
        }
        internal List<string> GetUsers()
        {
            IsConnect();
            string query = $"SELECT `login` FROM `idealist-users`";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> users = new List<string>();
            while (reader.Read())
            {
                users.Add(reader.GetString(0));
            }
            reader.Close();
            Close();
            return users;
        }
        internal List<string[]> GetLogsUser(string login)
        {
            IsConnect();
            string query = $"SELECT `created`, `caption-action`, `action` FROM `idealist-users-action` WHERE `user` = '{login}' ORDER BY `id` DESC";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string[]> logs = new List<string[]>();
            while (reader.Read())
            {
                logs.Add(new string[3] { reader.GetString(0), reader.GetString(1), reader.GetString(2) });
            }
            reader.Close();
            Close();
            return logs;
        }
        internal void WriteLogs(string login, string act, string action)
        {
            IsConnect();
            string query = $"INSERT INTO `idealist-users-action` (`user`, `caption-action`, `action`) VALUES ('{login}', '{act}', '{action}')";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            Close();
        }
    }
}
