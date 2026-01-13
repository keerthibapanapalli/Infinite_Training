using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDiscon
{
    public class Assessment
    {
        //connected
        //task2.1
        public void DisplayAllCourses()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB");
            con.Open();
            string query = "select CourseId, CourseName, Credits, Semester FROM Courses";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["CourseId"]}  {dr["CourseName"]}  {dr["Credits"]}  {dr["Semester"]}");
            }
            con.Close();
        }
        //task2.2
        public void Addstudent(string fullname, string email, string department, int yearofstudy)
        {
            string conn = "Integrated Security=true;Database=master;Server=(localdb)\\MSSQLLocalDB";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string query = @"insert into students(fullname, email, department, yearofstudy) values(@fullname, @email, @department, @yearofstudy)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@yearofstudy", yearofstudy);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine("inserted new student");
                }
                con.Close();
            }
        }
        //task2.3
        public void SearchbyDept(string department)
        {
            string conn = "Integrated Security=true;Database=master;Server=(localdb)\\MSSQLLocalDB";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string sql = @"select studentid, fullname, email, department, yearofstudy from students where lower(department) = lower(@department)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@department", department?.Trim() ?? string.Empty);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine("studentid | fullname | email | department | year");
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["studentid"]}  {dr["fullname"]}  {dr["email"]}  {dr["department"]}  {dr["yearofstudy"]}");
                        }
                    }
                }
            }
        }
        //task2.4
        public void Enrolledstudent(int studentid)
        {
            string conn = "Integrated Security=true;Database=master;Server=(localdb)\\MSSQLLocalDB";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string sql = @"select c.coursename, c.credits, e.enrolldate, e.grade from enrollments einner join courses c on e.courseid = c.courseid where e.studentid = @studentid order by e.enrolldate";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@studentid", studentid);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine("course name |credits |enroll date |grade");
                        while (dr.Read())
                        {
                            string courseName = Convert.ToString(dr["coursename"]);
                            int credits = Convert.ToInt32(dr["credits"]);
                            DateTime enrollDate = Convert.ToDateTime(dr["enrolldate"]);
                            string grade = Convert.ToString(dr["grade"]);
                            Console.WriteLine($"{courseName} | {credits} | {enrollDate} | {grade}");
                        }
                    }

                }
            }

        }
        public void Updategrade()
        {
            Console.Write("Enter EnrollmentId: ");
            int enrollmentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter grade: ");
            string grade = Console.ReadLine().ToUpper();
            string conn = "Integrated Security=true;Database=master;Server=(localdb)\\MSSQLLocalDB";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Enrollments set Grade = @Grade where EnrollmentId = @EnrollmentId", con);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);

                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine("grades updated");
            }
        }

    }
}
