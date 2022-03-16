using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SchoolDB_Assignment_EwertonXavier_w2022.Models;

namespace SchoolDB_Assignment_EwertonXavier_w2022.Controllers
{
    public class TeacherDataController : ApiController
    {
        /// <summary>
        /// This method is responsible for querying the school DB using the query provided as parameter
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List with query result</returns>
        private IEnumerable<string> QuerySchoolDB(string query)
        {
            List<string> queryResult = new List<string>();

            //instantiate model
            SchoolDbContext DbCtx = new SchoolDbContext();

            //instantiate connection
            MySqlConnection conn = DbCtx.AccessDatabase();

            //open connection
            conn.Open();

            //create command using connection
            MySqlCommand cmd = conn.CreateCommand();

            //write query for command
            cmd.CommandText = query;

            //run command and stores result into result
            MySqlDataReader results = cmd.ExecuteReader();


            //read results
            while (results.Read())
            {
                string result = "";//var to store the result of each row.
                for (int i = 0; i < results.FieldCount; i++)
                {
                    result += results.GetName(i) + ": " + results[i] + ", ";

                }
                result = result.TrimEnd(',', ' ');
                queryResult.Add(result);//add result string above to resultlist
            }
            //close DB connection
            conn.Close();
            return queryResult;
        }

        [HttpGet]
        public IEnumerable<string> ListTeacher()
        {
            return QuerySchoolDB("SELECT * FROM teachers");
        }

        [HttpGet]
        public IEnumerable<string> ListTeacherClasses(int? id)
        {

            if (id == null)
            {
                return QuerySchoolDB("SELECT t.teacherid, t.teacherfname, c.classname  FROM teachers t JOIN classes c ON (t.teacherid =c.teacherid) ORDER BY teacherid ASC;");
            }
            return QuerySchoolDB("SELECT t.teacherid, t.teacherfname, c.classname  FROM teachers t JOIN classes c ON (t.teacherid =c.teacherid) WHERE t.teacherid=" + id + "ORDER BY teacherid ASC;");

        }

    }
}
