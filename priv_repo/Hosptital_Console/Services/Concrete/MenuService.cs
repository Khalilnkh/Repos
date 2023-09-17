using System;
using ConsoleTables;
using Hosptital_Console.Data.Enums;
using Hosptital_Console.Services.Asbtract;

namespace Hosptital_Console.Services.Concrete
{
    public class MenuService
    {
        private static IHospitalService hospitalService = new HospitalService();

        public static void ShowDoctors()
        {
            var table = new ConsoleTable("ID", "Fullname", "Department", "Price Per Session");

            foreach (var doctor in hospitalService.GetDoctors())
            {
                table.AddRow(doctor.Id, doctor.Fullname, doctor.Department, doctor.PricePerSession);
            }

            table.Write();
        }

        public static void AddDoctor()
        {
            try
            {
                Console.WriteLine("Enter doctor's full name:");
                string fullname = Console.ReadLine()!;

                Console.WriteLine("Enter doctor's department:");
                Department department = (Department)Enum.Parse(typeof(Department), Console.ReadLine()!);

                Console.WriteLine("Enter doctor's price per session:");
                decimal pricePerSession = decimal.Parse(Console.ReadLine()!);

                int id = hospitalService.AddDoctor(fullname, department, pricePerSession);

                Console.WriteLine($"Doctor with ID:{id} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeleteDoctor()
        {
            try
            {
                Console.WriteLine("Enter doctor's ID:");
                int id = int.Parse(Console.ReadLine()!);

                hospitalService.DeleteDoctor(id);

                Console.WriteLine($"Doctor with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ShowPatients()
        {
            var table = new ConsoleTable("ID", "Fullname", "Phone");

            foreach (var patient in hospitalService.GetPatients())
            {
                table.AddRow(patient.Id, patient.Fullname, patient.Phone);
            }

            table.Write();
        }

        public static void AddPatient()
        {
            try
            {
                Console.WriteLine("Enter patient's full name:");
                string fullname = Console.ReadLine()!;

                Console.WriteLine("Enter patient's phone number:");
                string phone = Console.ReadLine()!;

                int id = hospitalService.AddPatient(fullname, phone);

                Console.WriteLine($"Patient with ID:{id} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeletePatient()
        {
            try
            {
                Console.WriteLine("Enter patient's ID:");
                int id = int.Parse(Console.ReadLine()!);

                hospitalService.DeletePatient(id);

                Console.WriteLine($"Patient with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ShowMeetings()
        {
            var table = new ConsoleTable("ID", "Dotor's fullname", "Patient's fullname", "Reason", "Date");

            foreach (var meeting in hospitalService.GetMeetings())
            {
                table.AddRow(meeting.Id, meeting.Doctor.Fullname, meeting.Patient.Fullname, meeting.Reason, meeting.Date);
            }

            table.Write();

        }

        public static void AddMeeting()
        {
            try
            {
                Console.WriteLine("List of available doctors:");
                ShowDoctors();

                Console.WriteLine("Enter doctor's ID:");
                int doctorId = int.Parse(Console.ReadLine()!);

                Console.WriteLine("List of available patients:");
                ShowPatients();

                Console.WriteLine("Enter patient's ID:");
                int patientId = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter meeting's reason:");
                var reason = Console.ReadLine()!;

                Console.WriteLine("Enter meeting's date (dd/MM/yyyy - HH:mm):");
                var date = DateTime.ParseExact(Console.ReadLine()!, "(dd/MM/yyyy - HH:mm)", null);

                int id = hospitalService.AddMeeting(doctorId, patientId, date, reason);

                Console.WriteLine($"Meeting with ID:{id} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void DeleteMeeting()
        {
            try
            {
                Console.WriteLine("Enter meeting's ID:");
                int id = int.Parse(Console.ReadLine()!);

                hospitalService.DeleteMeeting(id);

                Console.WriteLine($"Meeting with ID:{id} was deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ShowReport()
        {
            try
            {
                Console.WriteLine("Enter minimum date (dd/MM/yyyy - HH:mm):");
                var minDate = DateTime.ParseExact(Console.ReadLine()!, "(dd/MM/yyyy - HH:mm)", null);

                Console.WriteLine("Enter maximum date (dd/MM/yyyy - HH:mm):");
                var maxDate = DateTime.ParseExact(Console.ReadLine()!, "(dd/MM/yyyy - HH:mm)", null);

                var report = hospitalService.GetReport(minDate, maxDate);

                Console.WriteLine("Here is the report:");
                Console.WriteLine($"Meeting Count: {report.MeetingCount} | Income: {report.Income}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

