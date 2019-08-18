using MVCTestingWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Data;


namespace MVCTestingWithDatabase.View.Home
{
    public class ModifyStudentViewModel
    {

        public void AddStudentData(ModifyStudent Mstud,HttpPostedFileBase file)
        {
            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_saveData", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", Mstud.ID);
                    cmd.Parameters.AddWithValue("@Name", Mstud.Name);
                    cmd.Parameters.AddWithValue("@Address", Mstud.Addresss);
                    cmd.Parameters.AddWithValue("@Course", Mstud.Course);
                    if(file!=null && file.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string imgPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), fileName);
                        file.SaveAs(imgPath);
                    }
                    cmd.Parameters.AddWithValue("@Image", "~/Images/"+file.FileName);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<ModifyStudent> GetAllStudent()
        {
            List<ModifyStudent> stu = new List<ModifyStudent>();
            
            string conn = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand("sp_findData", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ModifyStudent student = new ModifyStudent();
                        student.ID = int.Parse(rdr["ID"].ToString());
                        student.Name = rdr["Name"].ToString();
                        student.Addresss = rdr["Address"].ToString();
                        student.Course = rdr["Course"].ToString();
                        student.Image = rdr["Image"].ToString();
                        stu.Add(student);
                    }
                }
            }
            return stu;
        }
    }
}