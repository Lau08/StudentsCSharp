using Students.Enums;
using Students.Models;
using System.Xml.Linq;

public class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
        new Student { firstName = "Laura", lastName = "Diaz", course = Course.Art },
        new Student { firstName = "Malena", lastName = "Alvarez", course = Course.History },
        new Student { firstName = "George", lastName = "Smith", course = Course.Mathematics },
        new Student { firstName = "Selena", lastName = "Gomez", course = Course.English },
        new Student { firstName = "Justin", lastName = "Bieber", course = Course.English },
        new Student { firstName = "Miley", lastName = "Cyrus", course = Course.Chemistry },
        new Student { firstName = "Ben", lastName = "Ken", course = Course.Physics },
        new Student { firstName = "Will", lastName = "Smith", course = Course.Art },
        new Student { firstName = "Clara", lastName = "Chía", course = Course.Mathematics },
        new Student { firstName = "Becky", lastName = "G", course = Course.Physics },
        };

        ClassroomManager(students);
        Console.ReadLine();
    }

    static void ClassroomManager(List<Student> students)
    {
        Console.WriteLine();
        Console.WriteLine("********************* WELLCOME TO THE CLASSROOM MANAGER *********************");
        Console.WriteLine();
        Console.WriteLine("To print a list of students by course type 1 or to add a new student type 2: ");
        string option = Console.ReadLine();

        if (option != null && option == "1")
        {
            Student.ListStudentsByCourse(students);
            Console.WriteLine();
            Console.ReadLine();
            ClassroomManager(students);
        }
        else if (option != null && option == "2")
        {
            string sName;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter student first name: ");
                sName = Console.ReadLine();
                inputCheck(sName);

            } while (string.IsNullOrWhiteSpace(sName) || !sName.All(c => char.IsLetter(c)) || sName.Count() <= 1);

            string sSecondName;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter student second name: ");
                sSecondName = Console.ReadLine();
                inputCheck(sSecondName);

            } while (string.IsNullOrWhiteSpace(sSecondName) || !sSecondName.All(c => char.IsLetter(c)) || sSecondName.Count() <= 1);

            string sLastName;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter student Last Name: ");
                sLastName = Console.ReadLine();
                inputCheck(sLastName);

            } while (string.IsNullOrWhiteSpace(sLastName) || !sLastName.All(c => char.IsLetter(c)) || sLastName.Count() <= 1);

            Console.WriteLine("Enter student course:");
            foreach (Course course in Enum.GetValues(typeof(Course)))
            {
                Console.WriteLine("{0}. {1}", (int)course, course);
            }

            int courseOption;
            do
            {
                Console.Write("Select an option (0-{0}): ", Enum.GetValues(typeof(Course)).Length - 1);
            } while (!int.TryParse(Console.ReadLine(), out courseOption) || !Enum.IsDefined(typeof(Course), courseOption));

            Course selectedCourse = (Course)courseOption;

            Student s = new Student { firstName = sName, secondName = sSecondName, lastName = sLastName, course = selectedCourse };
            Student.AddStudent(students, s);
            Console.WriteLine("Student added");
            Console.WriteLine("Name: {0} {1} {2}, Course: {3}", s.firstName, s.secondName, s.lastName, s.course);
            Console.WriteLine();
            Console.ReadLine();
            ClassroomManager(students);
        }
        else if (option == null || option == "" || option != "1" && option != "2")
        {
            ClassroomManager(students);
        }
    }

    public static void inputCheck(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || !input.All(c => char.IsLetter(c)))
        {
            Console.WriteLine("Make sure the input have no space or number!");
        } else if (input.Count() <= 1)
        {
            Console.WriteLine("Make sure the input has more than one character!");
        }
    }
}
