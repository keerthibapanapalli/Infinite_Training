using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDiscon
{
    public class Disconnected
    {
        //task3.1
        public void Stdcourses()
        {
            using (SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB"))
            {
                SqlDataAdapter daStudents = new SqlDataAdapter("select * from students", con);
                SqlDataAdapter daCourses = new SqlDataAdapter("select * from courses", con);
                DataSet ds = new DataSet();
                daStudents.Fill(ds, "Students");
                daCourses.Fill(ds, "Courses");
                Console.WriteLine("students");
                foreach (DataRow dr in ds.Tables["students"].Rows)
                {
                    Console.WriteLine($"{dr["Studentid"]}   {dr["fullname"]}   {dr["email"]}   {dr["department"]}   {dr["yearofstudy"]}");
                }

                Console.WriteLine("course");
                foreach (DataRow dr in ds.Tables["courses"].Rows)
                {
                    Console.WriteLine($"{dr["CourseId"]}   {dr["CourseName"]}   {dr["Credits"]}   {dr["Semester"]}");
                }
                Console.ReadLine();
            }
        }
        //task3.2
        public void Modifycoursecred()
        {
            using (SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB"))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from courses", con);
                SqlCommandBuilder cd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "courses");
                DataTable tbl = ds.Tables["courses"];
                tbl.PrimaryKey = new DataColumn[] { tbl.Columns["courseid"] };
                Console.Write("enter course to update:");
                int courseId = int.Parse(Console.ReadLine());
                Console.Write("enter new credits: ");
                int c = int.Parse(Console.ReadLine());
                DataRow row = tbl.Rows.Find(courseId);
                if (row != null)
                {
                    row["credits"] = c;
                    da.Update(ds, "courses");
                    Console.WriteLine("credits updated");
                }
            }
        }
        //task3.3
        public void Insertnewcourses()
        {
            using (SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB"))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from courses", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "courses");
                DataTable tbl = ds.Tables["courses"];
                Console.Write("course name: ");
                string name = Console.ReadLine();
                Console.Write("credits: ");
                int credits = int.Parse(Console.ReadLine());
                Console.Write("semester:");
                string semester = Console.ReadLine();
                DataRow nr = tbl.NewRow();

                nr["coursename"] = name;
                nr["credits"] = credits;
                nr["semester"] = semester;
                tbl.Rows.Add(nr);
                da.Update(ds, "courses");
                Console.WriteLine("New course inserted");
            }
        }
        //task3.4
        public void Deletestudent()
        {
            SqlConnection con = new SqlConnection("Integrated Security = true;database = master;server =(localdb)\\MSSQLLocalDB");
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from students", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Fill(ds, "students");
            Console.Write("Enter StudentId : ");
            int studentid = Convert.ToInt32(Console.ReadLine());
            DataRow[] row = ds.Tables["students"].Select("studentid = " + studentid);
            if (row.Length > 0)
            {
                row[0].Delete();
                da.Update(ds, "students");
            }
            con.Close();
            Console.ReadLine();
        }
        //stored procedures
        public void GetCoursesBySemester()
        {
            Console.Write("enter semester: ");
            string semester = Console.ReadLine();

            using (SqlConnection con=new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB"))
            {
                con.Open();
                using (SqlCommand cmd =new SqlCommand("usp_GetCoursesBySemester", con))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@semester", semester);
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        Console.WriteLine("CourseId | CourseName | Credits | Semester");
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["CourseId"]}   {dr["CourseName"]}   {dr["Credits"]}   {dr["Semester"]}");
                        }
                    }
                }
            }
        }
    }    
    
}
