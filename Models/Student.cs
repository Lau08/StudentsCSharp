using Students.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    internal class Student
    {
        public string firstName;
        public string lastName;
        public Course course;

        public static void AddStudent(List<Student> studentList ,Student student)
        {
            studentList.Add(student);
        }

        public static void ListStudentsByCourse(List<Student> students)
        {
            var studentsByCourse = from s in students
                                   group s by s.course into Courses
                                   select Courses;

            foreach (var courseGroup in studentsByCourse)
            {
                Console.WriteLine("Students in {0} course:", courseGroup.Key);

                foreach (var student in courseGroup)
                {
                    Console.WriteLine("{0} {1}", student.firstName, student.lastName);
                }

                Console.WriteLine();
            }
        }
    }


}
