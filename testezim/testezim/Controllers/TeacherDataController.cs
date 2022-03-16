using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testezim.Models;
using MySql.Data.MySqlClient;

namespace testezim.Controllers
{
    public class TeacherDataController : ApiController
    {



        /// <summary>
        /// Api to retrieve list of all Teacher Basic info (ids, first name, and last name). 
        /// Example:
        /// Request: GET /api/TeacherData/BasicInfo
        /// Response: id:"1" fname:"John" lname:"Doe",
        ///           id:"2" fname:"Christie" lname:"Bittle",
        /// </summary>
        /// <returns> List<string> BasicInfo</returns>
        [HttpGet]
        public IEnumerable<string> BasicInfo()
        {
            List<string> resultList = new List<string> { }; // initiate list

            //instantiate connection with schoolDB using SchoolDbContext
            MySqlConnection conn = new SchoolDbContext().AccessDatabase();

            //open connection with DB
            conn.Open();

            //create command using connection
            MySqlCommand cmd = conn.CreateCommand();

            //write query into command
            cmd.CommandText = "SELECT teacherid, teacherfname,teacherlname FROM teachers";

            //run command and stores results
            MySqlDataReader results = cmd.ExecuteReader();

            //read each line from results. results.Read() returns false if row is null. 
            while (results.Read())
            {
                string result = "";//var to store the result of each row.
                for (int i = 0; i < results.FieldCount; i++)
                {
                    result += results.GetName(i)+": " + results[i]+", ";
                    
                }
                result = result.TrimEnd(',',' ');
                resultList.Add(result);//add result string above to resultlist
            }
            //close DB connection
            conn.Close();
            return resultList;
        }
    }
}
