using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Check
{
    static class Log
    {
        private static readonly User user = new User();
        private static readonly DBConnection dbCon = new DBConnection();

        public static void Write(string act, string action)
        {
            dbCon.WriteLogs(user.GetLogin(), act, action);
        }
    }
}
