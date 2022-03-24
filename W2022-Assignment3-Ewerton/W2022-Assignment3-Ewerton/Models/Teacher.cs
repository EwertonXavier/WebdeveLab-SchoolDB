using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022_Assignment3_Ewerton.Models
{
    /// <summary>
    /// Used to intantiate a Teacher Object. 
    /// Teacher contains:Id, FName, LName, EmployeeNumber, HireDate, Salary
    /// </summary>
    /// <example>Teacher teacher = new Teacher()</example>
    public class Teacher
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }

        /// <summary>
        /// Functions to populate Teacher data with dummy values.
        /// </summary>
        public void Anonymize() 
        {
            Id = -1;
            FName = "unknow";
            LName = "unknow";
            EmployeeNumber = "-1";
            HireDate = new DateTime();
            Salary = 0.00f;
        }


    }
}