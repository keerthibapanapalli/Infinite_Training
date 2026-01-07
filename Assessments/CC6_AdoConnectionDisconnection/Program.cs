using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssessmentDiscon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assessment ob=new Assessment();
            //ob.DisplayAllCourses();

            //Console.Write("enter full name: ");
            //string fullname = Console.ReadLine();
            //Console.Write("enter email: ");
            //string email = Console.ReadLine();
            //Console.Write("enter department: ");
            //string department = Console.ReadLine();
            //Console.Write("enter year of study: ");
            //int year = Convert.ToInt32(Console.ReadLine());
            //ob.Addstudent(fullname,email,department,year);

            //Console.Write("enter department: ");
            //string dept = Console.ReadLine();
            //ob.SearchbyDept(dept);

            //Console.Write("enter student id: ");
            //int studentId = Convert.ToInt32(Console.ReadLine());
            //ob.Enrolledstudent(studentId);

            //ob.Updategrade();

            Disconnected ob1=new Disconnected();
            //ob1.Stdcourses();
            //ob1.Modifycoursecred();
            //ob1.Insertnewcourses();
            //ob1.Deletestudent();
            ob1.GetCoursesBySemester();

            Console.ReadLine();

        }
    }
}
