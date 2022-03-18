using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using W2022_Assignment3_Ewerton.Models;
using MySql.Data.MySqlClient;

namespace W2022_Assignment3_Ewerton.Controllers
{
    /// <summary>
    /// API to retrieve Teacher data from SchoolDB database
    /// </summary>
    public class TeacherDataController : ApiController
    {
        /// <summary>
        /// Describe all information related to teacherid stored inside the teachers table
        /// </summary>
        /// <param name="teacherid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TeacherData/Describe/{teacherid}")]
        public Teacher Describe(int teacherid)
        {
            //creating db context
            SchoolDbContext dbCtx = new SchoolDbContext();

            //creating connection to schoolDB 
            MySqlConnection conn = dbCtx.AccessDatabase();

            //opening connection
            conn.Open();

            //creating command
            MySqlCommand cmd = conn.CreateCommand();

            //writing command query which select all information from teacher table using parameter teacher to filter rows
            cmd.CommandText = "SELECT * FROM teachers t WHERE teacherid =" + teacherid + " ;";

            //execute command
            MySqlDataReader teachers = cmd.ExecuteReader();

            Teacher teacher = new Teacher(); //object to represent teacher data

            if (teachers.Read()) //I assumed the query will only bring one result. If more rows are return, only the first will be read. 
            {
                teacher.FName = teachers["teacherfname"].ToString();
                teacher.LName = teachers["teacherlname"].ToString();
                teacher.Id = Convert.ToInt32(teachers["teacherid"]);
                teacher.HireDate = Convert.ToDateTime(teachers["hiredate"]);
                teacher.Salary = Convert.ToDouble(teachers["salary"]);
                teacher.EmployeeNumber = teachers["employeenumber"].ToString();//besides the name saying "number" it s not a number :D
            }
            else
            {//case there is no string returned
                teacher.Anonymize();
            }
            conn.Close(); // close connection with DB
            return teacher;
        }

        /// <summary>
        /// Fetch all teachers info from teachers table
        /// </summary>
        /// <returns>A list<Teacher> with all attributes()</returns>
        [HttpGet]
        [Route("api/TeacherData/List/")]
        public List<Teacher> List()
        {
            //creating db context
            SchoolDbContext dbCtx = new SchoolDbContext();

            //creating connection to schoolDB 
            MySqlConnection conn = dbCtx.AccessDatabase();

            //opening connection
            conn.Open();

            //creating command
            MySqlCommand cmd = conn.CreateCommand();

            //writing command query which select all information from teacher table using parameter teacher to filter rows
            cmd.CommandText = "SELECT * FROM teachers t;";

            //execute command store rows in reachers
            MySqlDataReader teachers = cmd.ExecuteReader();

            //list to store all Intances of Teachers created from db
            List<Teacher> teacherList = new List<Teacher>(); 

            while (teachers.Read()) //reads each row from query
            {
                //object to represent teacher data
                Teacher teacher = new Teacher();
                teacher.FName = teachers["teacherfname"].ToString();
                teacher.LName = teachers["teacherlname"].ToString();
                teacher.Id = Convert.ToInt32(teachers["teacherid"]);
                teacher.HireDate = Convert.ToDateTime(teachers["hiredate"]);
                teacher.Salary = Convert.ToDouble(teachers["salary"]);
                teacher.EmployeeNumber = teachers["employeenumber"].ToString();//besides the name saying "number" it s not a number :D
                teacherList.Add(teacher); // adds the created teacher to the list
            }

            return teacherList;
        }


    }
}
