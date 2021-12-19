using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Delivery_Check
{
    class ColorTable
    {
        private readonly String path;
        private readonly RegisterIni ini;

        private System.Drawing.Color succeededColor;
        private System.Drawing.Color latecomerColor;

        public System.Drawing.Color Succeeded
        {
            get => succeededColor;
        }
        public System.Drawing.Color Latecomer
        {
            get => latecomerColor;
        }

        public ColorTable()
        {
            path = Directory.GetCurrentDirectory() + "/resource.ini";
            ini = new RegisterIni(path);
            String succeededColorIni;
            String latecomerColorIni;


            if (!File.Exists(path))
            {
                using StreamWriter iniFile = File.CreateText(path);
                string[] s = new string[3]
                {
                        Properties.Settings.Default.succeeded.R.ToString(),
                        Properties.Settings.Default.succeeded.G.ToString(),
                        Properties.Settings.Default.succeeded.B.ToString()
                };
                string[] l = new string[3]
                {
                        Properties.Settings.Default.latecomer.R.ToString(),
                        Properties.Settings.Default.latecomer.G.ToString(),
                        Properties.Settings.Default.latecomer.B.ToString()
                };
                iniFile.WriteLine("[ColorOrders]");
                iniFile.WriteLine($"succeeded={s[0]};{s[1]};{s[2]}");
                iniFile.WriteLine($"latecomer={l[0]};{l[1]};{l[2]}");
            }

            succeededColorIni = ini.GetPrivateString("ColorOrders", "succeeded");
            latecomerColorIni = ini.GetPrivateString("ColorOrders", "latecomer");

            try
            {
                string[] succsesC = succeededColorIni.Split(';');
                succeededColor = System.Drawing.Color.FromArgb(int.Parse(succsesC[0]), int.Parse(succsesC[1]), int.Parse(succsesC[2]));
            }
            catch (Exception)
            {
                succeededColor = Properties.Settings.Default.succeeded;
                ini.WritePrivateString("ColorOrders", "succeeded", $"{succeededColor.R};{succeededColor.G};{succeededColor.B}");
            }
            try
            {
                string[] latecomerC = latecomerColorIni.Split(';');
                latecomerColor = System.Drawing.Color.FromArgb(int.Parse(latecomerC[0]), int.Parse(latecomerC[1]), int.Parse(latecomerC[2]));
            }
            catch (Exception)
            {
                latecomerColor = Properties.Settings.Default.latecomer;
                ini.WritePrivateString("ColorOrders", "latecomer", $"{latecomerColor.R};{latecomerColor.G};{latecomerColor.B}");
            }
        }

        public void SetSucceeded(System.Drawing.Color succeeded)
        {
            succeededColor = succeeded;
            ini.WritePrivateString("ColorOrders", "succeeded", $"{succeededColor.R};{succeededColor.G};{succeededColor.B}");
            Properties.Settings.Default.succeeded = succeededColor;
            Properties.Settings.Default.Save();
        }
        public void SetLatecomer(System.Drawing.Color latecomer)
        {
            latecomerColor = latecomer;
            ini.WritePrivateString("ColorOrders", "latecomer", $"{latecomerColor.R};{latecomerColor.G};{latecomerColor.B}");
            Properties.Settings.Default.latecomer = latecomerColor;
            Properties.Settings.Default.Save();
        }
    }
    class User
    {
        private readonly String path;
        private readonly RegisterIni ini;

        private String login;
        private String password;
        public User()
        {
            path = Directory.GetCurrentDirectory() + "/user_auth.ini";
            ini = new RegisterIni(path);

            if (!File.Exists(path))
            {
                using StreamWriter iniFile = File.CreateText(path);
                iniFile.WriteLine("[User]");
                iniFile.WriteLine("login=");
                iniFile.WriteLine("password=");
            }

            login = ini.GetPrivateString("User", "login");
            password = ini.GetPrivateString("User", "password");
        }
        public void SetAuth(String StrLogin, String StrPassword)
        {
            SetLogin(StrLogin);
            SetPassword(StrPassword);
        }
        public void SetLogin(String StrLogin)
        {
            login = StrLogin;
            ini.WritePrivateString("User", "login", login);
        }
        public void SetPassword(String StrPassword)
        {
            //password = MyEncrypt.Encrypt(StrPassword, Properties.Settings.Default.encryptUser);
            password = StrPassword;
            ini.WritePrivateString("User", "password", password);
        }

        public String GetLogin()
        {
            return login;
        }
        public String GetPassword()
        {
            return password;
        }
    }

    class RegisterIni
    {
        private readonly String path;
        public RegisterIni(String path)
        {
            this.path = path;
        }
        //Возвращает значение из INI-файла (по указанным секции и ключу)
        public string GetPrivateString(string aSection, string aKey)
        {
            //Для получения значения
            StringBuilder buffer = new StringBuilder(1024);

            //Получить значение в buffer
            GetPrivateString(aSection, aKey, null, buffer, 1024, path);

            //Вернуть полученное значение
            return buffer.ToString();
        }

        //Пишет значение в INI-файл (по указанным секции и ключу) 
        public void WritePrivateString(string aSection, string aKey, string aValue)
        {
            //Записать значение в INI-файл
            WritePrivateString(aSection, aKey, aValue, path);
        }
        //Импорт функции GetPrivateProfileString(для чтения значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

        //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateString(string section, string key, string str, string path);
    }
}
