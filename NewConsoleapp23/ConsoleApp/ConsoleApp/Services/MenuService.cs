
using amqp.Data.Models;
using ConsoleTables;

namespace amqp.Services
{
    public class MenuService
    {
        private static ClassroomService classroomService = new();

        public static void MenuAddClassroom()
        {
            try
            {
                Console.WriteLine("Enter classroom's name:");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter classroom's subject:");
                string subject = Console.ReadLine()!;

                int classRoomId = classroomService.AddClassroom(name, subject);

                Console.WriteLine($"Classroom with ID:{classRoomId} was created!");
            }
            catch (Exception ex)

            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuDeleteClassroom()
        {
            try
            {
                Console.WriteLine("Enter classroom's id:");
                int id = int.Parse(Console.ReadLine()!);

                classroomService.DeleteClassroom(id);

                Console.WriteLine($"Classroom with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuShowClassrooms()
        {
            var table = new ConsoleTable("ID", "Name", "Subject");

            foreach (var classroom in classroomService.ShowClassrooms())
            {
                table.AddRow(classroom.Id, classroom.Name, classroom.Subject);
            }

            table.Write();
        }

        public static void MenuAddStudent()
        {
            try
            {
                Console.WriteLine("Enter student's name:");
                string name = Console.ReadLine()!;

                Console.WriteLine("Enter student's surname:");
                string surname = Console.ReadLine()!;

                Console.WriteLine("Enter student's birthday (MM/dd/yyyy):");
                DateOnly birthday = DateOnly.Parse(Console.ReadLine()!);

                int studentId = classroomService.AddStudent(name, surname, birthday);

                Console.WriteLine($"Student with ID:{studentId} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuDeleteStudent()
        {
            try
            {
                Console.WriteLine("Enter students's id:");
                int id = int.Parse(Console.ReadLine()!);

                classroomService.DeleteStudent(id);

                Console.WriteLine($"Student with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuShowStudents()
        {
            var table = new ConsoleTable("ID", "Name", "Surname", "Birthday");

            foreach (var student in classroomService.ShowStudents())
            {
                table.AddRow(student.Id, student.Name, student.Surname, student.Birthday);
            }

            table.Write();
        }
        public static void MenuUpdateClassrom()
        {
            
                Console.WriteLine("Enter new classrooms's Id:");
                int DbId = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter new classrooms's name:");
                string DbName = Console.ReadLine()!;
                Console.WriteLine("Enter new classrooms's subject:");
                string DbSubject = Console.ReadLine()!;
                var updatedclassroom = new Classroom()
                {
                    Id = DbId,
                    Name = DbName,
                    Subject = DbSubject,

                };
                classroomService.UpdateClassroom(DbId, DbName, DbSubject);
            Console.WriteLine($"Updated id {updatedclassroom.Id} New Classroom name  {updatedclassroom.Name}  New Classroom subject {updatedclassroom.Subject}");


        }

        public static void MenuUpdateStudent()
        {
            Console.WriteLine("Enter new student Id:");
            int DbId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter new student name:");
            string DbName = Console.ReadLine()!;
            Console.WriteLine("Enter new student surname:");
            string Dbsurname = Console.ReadLine()!;
            Console.WriteLine("Enter new student birthday (MM/dd/yyyy):");
            DateOnly Dbbirthday = DateOnly.Parse(Console.ReadLine()!);
            var updatedStudent = new Student()
            {
                Id = DbId,
                Name = DbName,
                Surname=Dbsurname,
                Birthday=Dbbirthday
                

            };
            classroomService.UpdateStudent(DbId, DbName, Dbsurname,Dbbirthday);
            Console.WriteLine($"Updated id {updatedStudent.Id} New Student  name  {updatedStudent.Name}  New Student Surname {updatedStudent.Surname}  New Student Birthday {updatedStudent.Birthday}");



        }
    }
}