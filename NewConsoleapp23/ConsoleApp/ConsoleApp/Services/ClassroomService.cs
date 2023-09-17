using System;
using System.Collections.Generic;
using amqp.Data.Models;
using System.Linq;
using System.Xml.Linq;

namespace amqp.Services
{
    public class ClassroomService
    {
        private static List<Classroom> _classrooms { get; set; }
        private static List<Student> _students { get; set; }

        public ClassroomService()
        {
            _classrooms = new();
            _students = new();
        }

        public int AddClassroom(string name, string subject)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name can't be empty!");

            if (string.IsNullOrWhiteSpace(subject))
                throw new Exception("Subject can't be empty!");

            var classroom = new Classroom
            {
                Name = name,
                Subject = subject
            };

            _classrooms.Add(classroom);

            return classroom.Id;
        }

        public void DeleteClassroom(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be less than 0!");

            var classroom = _classrooms.FirstOrDefault(x => x.Id == id);

            if (classroom == null)
                throw new Exception($"Classroom with ID:{id} was not found!");

            _classrooms.RemoveAll(x => x.Id == id);
        }

        public List<Classroom> ShowClassrooms()
        {
            return _classrooms;
        }

        public int AddStudent(string name, string surname, DateOnly birthday)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name can't be empty!");

            if (string.IsNullOrWhiteSpace(surname))
                throw new Exception("Surname can't be empty!");

            if (DateTime.Now.Year-birthday.Year < 10 || DateTime.Now.Year-birthday.Year > 120)
                throw new Exception("Invalid age (birthday)!");

            var student = new Student
            {
                Name = name,
                Surname = surname,
                Birthday = birthday
            };

            _students.Add(student);

            return student.Id;
        }

        public void DeleteStudent(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be less than 0!");

            var student = _students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                throw new Exception($"Student with ID:{id} was not found!");

            _students.RemoveAll(x => x.Id == id);
        }

        public List<Student> ShowStudents()
        {
            return _students;
        }

        public void UpdateClassroom(int id,string newname,string newsubject)
        {
            try
            {
                var classroom = _classrooms.Find(x => x.Id == id);
                if (classroom!=null)
                {
                    classroom.Name = newname;
                classroom.Subject = newsubject;

                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");

            }
        }
        public void UpdateStudent(int id,string newName,string newSurname, DateOnly newBirthday)
        {
            try
            {
                var student = _students.Find(x => x.Id == id);
                if (student != null)
                {
                    student.Name = newName;
                    student.Surname = newSurname;
                    student.Birthday = newBirthday;

                }

            }
            catch (Exception)
            {

               Console.WriteLine("Something went wrong");

            }
        }
    }
}