using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using testezim.Models;

namespace testezim.Controllers
{
    public class TesteController : ApiController
    {
        [HttpGet]
        public string ConnectionTest()
        {
            SchoolDbContext DbCtx = new SchoolDbContext();
            
            //instantiate connection
            MySqlConnection conn = DbCtx.AccessDatabase();

            //open connection
            conn.Open();

            //create command using connection
            MySqlCommand cmd = conn.CreateCommand();

            //write query for command
            cmd.CommandText = "Select * from teachers";

            //run command and stores result into result
            MySqlDataReader result = cmd.ExecuteReader();

            string message="";

            //read results
            while (result.Read())
            {
                message += result["teacherfname"]+ " |";
            };
            return message;
        }
    }
}
