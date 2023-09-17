using System;
using Hosptital_Console.Services.Concrete;

namespace Hosptital_Console.Helpers
{
    public class SubMenuHelper
    {
        public static void DisplayDoctorMenu()
        {
            int selectedOption;

            do
            {
                Console.WriteLine("1. Show doctors");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Delete Doctor");

                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please, select an option:");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOption)
                {
                    case 1:
                        MenuService.ShowDoctors();
                        break;
                    case 2:
                        MenuService.AddDoctor();
                        break;
                    case 3:
                        MenuService.DeleteDoctor();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (selectedOption != 0);
        }

        public static void DisplayPatientMenu()
        {
            int selectedOption;

            do
            {
                Console.WriteLine("1. Show patients");
                Console.WriteLine("2. Add patient");
                Console.WriteLine("3. Delete patient");

                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please, select an option:");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOption)
                {
                    case 1:
                        MenuService.ShowPatients();
                        break;
                    case 2:
                        MenuService.AddPatient();
                        break;
                    case 3:
                        MenuService.DeletePatient();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (selectedOption != 0);
        }

        public static void DisplayMeetingMenu()
        {
            int selectedOption;

            do
            {
                Console.WriteLine("1. Show meetings");
                Console.WriteLine("2. Add meeting");
                Console.WriteLine("3. Delete meeting");
                Console.WriteLine("4. Show report");

                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please, select an option:");

                while (!int.TryParse(Console.ReadLine(), out selectedOption))
                {
                    Console.WriteLine("Please enter valid option:");
                }

                switch (selectedOption)
                {
                    case 1:
                        MenuService.ShowMeetings();
                        break;
                    case 2:
                        MenuService.AddMeeting();
                        break;
                    case 3:
                        MenuService.DeleteMeeting();
                        break;
                    case 4:
                        MenuService.ShowReport();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (selectedOption != 0);
        }

    }
}

