using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace SchoolDB_Assignment_EwertonXavier_w2022.Models
{
    public class SchoolDbContext
    {
        
            //create variables needed to create connections string
            private static string ServerName { get { return "localhost"; } }
            private static string Dbname { get { return "schooldb"; } }
            private static int Port { get { return 3306; } }

            private static string Username { get { return "root"; } }
            private static string Password { get { return "root"; } }

            //create connection string
            //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
            private string ConnectionString
            {
                get
                {
                    return "Server=" + ServerName +
                           ";Port=" + Port +
                           ";Database=" + Dbname +
                           ";Uid=" + Username +
                           ";Pwd=" + Password + ";";
                }
            }
            /// <summary>
            /// Instantiate a Db connection to database schooldb
            /// </summary>
            /// <returns>MysqlConnection</returns>
            public MySqlConnection AccessDatabase()
            {
                return new MySqlConnection(ConnectionString);
            }

        
    }
}