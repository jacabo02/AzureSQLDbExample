using CORSExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CORSExampleAPI.Services
{
    public class CourseService
    {

        public List<Course> CourseList;

        private SqlConnection GetConnection(string connectionstring)
        {
            return new SqlConnection(connectionstring);
        }

        public CourseService()
        {
        }

        public IEnumerable<Course> GetCourses(string connectionString)
        {
            CourseList = new List<Course>();
            string query = "Select CourseID, CourseName, Rating From Course";

            using(SqlConnection connection = GetConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            CourseList.Add(
                                new Course
                                {
                                    CourseID = Convert.ToInt32(reader["CourseID"]),
                                    CourseName = Convert.ToString(reader["CourseName"]),
                                    Rating = Convert.ToDecimal(reader["Rating"])
                                });
                        }
                    }
                }
                connection.Close();
            }

            return CourseList;
        }
    }
}
