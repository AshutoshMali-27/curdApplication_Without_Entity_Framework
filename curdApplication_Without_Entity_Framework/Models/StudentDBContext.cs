using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace curdApplication_Without_Entity_Framework.Models
{
    public class StudentDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<ClsStudentscs> GetStudents()
        {
            List<ClsStudentscs> StudentList = new List<ClsStudentscs>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Sp_StudentDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClsStudentscs std = new ClsStudentscs();
                std.id = Convert.ToInt32(dr.GetValue(0).ToString());
                std.Name = Convert.ToString(dr.GetValue(1).ToString());
                std.Gender = Convert.ToString(dr.GetValue(2).ToString());
                std.Age = Convert.ToInt32(dr.GetValue(3).ToString());

                StudentList.Add(std);
            }
            con.Close();

            return StudentList;
        }


        public bool AddStudents(ClsStudentscs std)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Sp_SETStudentDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Gender",std.Gender);
            cmd.Parameters.AddWithValue("@Age",std.Age);
            con.Open();
           int i= cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UpdatestudentDetail(ClsStudentscs std)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SP_UpdateStudents", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", std.id);
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Age", std.Age);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeletestudentDetail(int id)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SP_deleteStudent", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
          
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}