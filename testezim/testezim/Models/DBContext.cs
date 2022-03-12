using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace testezim.Models
{
    public class DBContext
    {
        //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;

        //create variables
        

        //start creating connection string
        public static string ConnectString
        {
            get { return "Server=localhost;Database=blog;Uid=root;Pwd=root;"; }

        }
        public string ConnectionTest()
        {
            //create an instance of connection
            MySqlConnection conn = new MySqlConnection();//Here I can use conn properties/methods

            //open connection
            conn.Open();
            return "";
        }
        MySqlConnection conn2 = new MySqlConnection();
        //conn2.Open();

    }

}