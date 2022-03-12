using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace testezim.Models
{
    public class DBContext2
    {
        //createvariables
        private static string Server { get { return "localhost"; } }
        private static string DbName { get { return "blog"; } }

        private static int Port { get { return 3306; } }

        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }

        //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
        //create connection string
        private static string ConnectionString { get {
                return "Server=" + Server
                    + ";Port=" + Port
                    + ";Database=" + DbName
                    + ";Uid=" + User
                    + ";Pwd=" + Password;
            } }

        //function to instantiate connection
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }


    }

}