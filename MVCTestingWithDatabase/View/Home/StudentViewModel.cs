using MVCTestingWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MVCTestingWithDatabase.View.Home
{
    public class StudentViewModel
    {
        public List<Student> GetAllStudent()
        {
            List<Student> stu = new List<Student>();

            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_getData", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Student student = new Student();
                        student.Roll = int.Parse(rdr["Roll"].ToString());
                        student.Name = rdr["Name"].ToString();
                        student.Course = rdr["Course"].ToString();
                        stu.Add(student);
                    }
                }
            }

            return stu;
        }

        public Student GetAllStudentDetailsById(int id)
        {
            Student student = new Student();

            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_getDataByID", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();

                    student.Roll = int.Parse(rdr["Roll"].ToString());
                    student.Name = rdr["Name"].ToString();
                    student.Course = rdr["Course"].ToString();

                }
            }
            return student;
        }

        public Student DeleteStudentById(int id)
        {
            Student student = new Student();

            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_deleteDataByID", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return student;
        }

        public void EditStudentData(Student stud)
        {
            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_editData", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Roll", stud.Roll);
                    cmd.Parameters.AddWithValue("@Name", stud.Name);
                    cmd.Parameters.AddWithValue("@Course", stud.Course);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddStudentData(Student stud)
        {
            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_addData", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Roll", stud.Roll);
                    cmd.Parameters.AddWithValue("@Name", stud.Name);
                    cmd.Parameters.AddWithValue("@Course", stud.Course);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}