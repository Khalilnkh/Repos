using Hosptital_Console.Helpers;

namespace Hospital_Console;

public class Program
{
    public static void Main(string[] args)
    {
        int selectedOption;

        Console.WriteLine("Welcome to Hospital!");

        do
        {
            Console.WriteLine("1. For managing doctors");
            Console.WriteLine("2. For managing patients");
            Console.WriteLine("3. For managing meetings");

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
                    SubMenuHelper.DisplayDoctorMenu();
                    break;
                case 2:
                    SubMenuHelper.DisplayPatientMenu();
                    break;
                case 3:
                    SubMenuHelper.DisplayMeetingMenu();
                    break;
                case 0:
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("No such option!");
                    break;
            }
        } while (selectedOption != 0);
    }
}