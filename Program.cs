using System;
/* 
 * Project Name: Langham Hotel
 * Author Name: Ann Patricia Calma
 * Date: 29/03/24
 * Application Purpose: To help Langham hotel in their day-to-day operations
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;

namespace Assessment2Task2
{
    // Custom Main Class - Program
    class Program
    {
        static void AddRooms()
        {
            try
            {
                Console.Write("Please Enter the Total Number of Rooms in the Hotel: ");
                int room = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter room number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                using (StreamWriter sw = new StreamWriter(Path.Combine("C:\\Users\\ADMIN\\Documents\\HotelManagement.txt")))
                {
                    for (int i = 1; i <= room; i++)
                    {
                        sw.WriteLine("Room No." + i);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
        public static void DisplayRooms()
        {
            Console.WriteLine("ROOMS AT LANGHAM HOTEL");
            string filePath = @"C:\\Users\\ADMIN\\Documents\HotelManagement.txt";
            try
            {
                string display;
                display = File.ReadAllText(filePath);
                Console.WriteLine(display);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException handled " + ex.Message);
            }
        }
        static void AllocateRoom()
        {
            string file = @"C:\\Users\\ADMIN\\Documents\\Allocation.txt";

            if (File.Exists(file))
            {
                Console.WriteLine();
            }
            else
            {
                FileStream fs = new FileStream("C:\\Users\\ADMIN\\Documents\\Allocation.txt", FileMode.Create);
                fs.Close();
            }
            Console.Write("How many rooms you want to allocate : ");
            int aRooms = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your Phone Number : ");
            string phone = Console.ReadLine();
            Console.Write("Enter your address : ");
            string add = Console.ReadLine();
            Console.WriteLine();
            using (StreamWriter sw = new StreamWriter(Path.Combine("C:\\Users\\ADMIN\\Documents\\Allocation.txt"), true))
            {
                sw.WriteLine("ROOM ALLOCATION DETAILS");
                for (int i = 1; i <= aRooms; i++)
                {
                    Console.Write("Please enter the room you want to allocate: ");
                    int allocateRooms = Convert.ToInt32(Console.ReadLine());
                    sw.WriteLine("\nDate and Time : " + dateTime);
                    sw.WriteLine("Customer name : " + name);
                    sw.WriteLine("Customer Phone Number: " + phone);
                    sw.WriteLine("Customer address : " + add);
                    sw.WriteLine("Room number you want to allocate: " + allocateRooms);
                    sw.WriteLine();
                }
            }
        }
        static void DeAllocate()
        {
            Console.Write("How many rooms you want to de-allocate : ");
            int deAllocate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your Phone Number : ");
            string phone = Console.ReadLine();
            Console.Write("Enter your address : ");
            string add = Console.ReadLine();
            Console.WriteLine();
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine("C:\\Users\\ADMIN\\Documents\\Allocation.txt"), true))
                {
                    sw.WriteLine("ROOM DE-ALLOCATION DETAILS");
                    for (int i = 1; i <= deAllocate; i++)
                    {
                        Console.Write("Enter the rooms you want to de-allocate : ");
                        int deAllo = Convert.ToInt32(Console.ReadLine());
                        sw.WriteLine("\nDate and Time : " + dateTime);
                        sw.WriteLine("Customer name : " + name);
                        sw.WriteLine("Customer Phone Number: " + phone);
                        sw.WriteLine("Customer address : " + add);
                        sw.WriteLine("Room number you want to de-allocate: " + deAllo);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }

        }
        static void DisplayRoomAllocation()
        {
            string filePath = @"C:\\Users\\ADMIN\\Documents\Allocation.txt";
            try
            {
                string display;
                display = File.ReadAllText(filePath);
                Console.WriteLine(display);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException handled " + ex.Message);
            }
        }
        static void SaveRoom()
        {
            try
            {
                string src = @"C:\\Users\\ADMIN\\Documents\HotelManagement.txt";
                string dest = @"C:\\Users\\ADMIN\\Documents\\Allocation.txt";
                string path = @"C:\\Users\\ADMIN\\Documents\\lhms_studentid.txt";
                if (File.Exists(path))
                {
                    Console.WriteLine();
                }
                else
                {
                    FileStream fs = new FileStream("C:\\Users\\ADMIN\\Documents\\lhms_studentid.txt", FileMode.Create);
                    fs.Close();
                }
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("LANGHAM HOTEL ROOM DATA");
                    sw.WriteLine("\nLIST OF ROOMS AT THE HOTEL");
                    sw.WriteLine(File.ReadAllText(src));
                    sw.WriteLine("\nALLOCATION HISTORY");
                    sw.WriteLine(File.ReadAllText(dest));
                }
                Console.WriteLine("The Room Allocation Has been Saved!");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
        static void ShowRoom ()
        {
            try
            {
                string path = @"C:\\Users\\ADMIN\\Documents\\lhms_studentid.txt";
                string display;
                display = File.ReadAllText(path);
                Console.WriteLine(display);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }
        static void BackUP()
        {
            try
            {
                string src = @"C:\\Users\\ADMIN\\Documents\\lhms_studentid.txt";
                string desc = @"C:\\Users\\ADMIN\\Documents\\lhms_studentid_BackUp.txt";

                File.Copy(src, desc);
                Console.WriteLine("The files has been backup");
                Console.ReadLine();
                IEnumerable<string> line = File.ReadLines(src);
                File.AppendAllLines(desc, line);

                Console.WriteLine("File is appended successfully! ");
                using (FileStream fs = new FileStream(src, FileMode.Open))
                {
                    fs.SetLength(0);
                }
                Console.WriteLine("Content in the file successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException handled " + ex.Message);
            }
        }
        public static string filePath;
        public static string dateTime = DateTime.Now.ToString();

        static void Main(string[] args)
        {
            
            char ans;
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(folderPath, "HotelManagement.txt");
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("                   LANGHAM HOTEL MANAGEMENT SYSTEM");
                    Console.WriteLine("                                 MENU");
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("1. Add Rooms");
                    Console.WriteLine("2. Display Rooms");
                    Console.WriteLine("3. Allocate Rooms");
                    Console.WriteLine("4. De-Allocate Rooms");
                    Console.WriteLine("5. Display Room Allocation Details");
                    Console.WriteLine("6. Billing");
                    Console.WriteLine("7. Save the Room Allocations To a File");
                    Console.WriteLine("8. Show the Room Allocations From a File");
                    Console.WriteLine("9. Exit");
                    Console.WriteLine("0. BackUp");
                    Console.WriteLine("***********************************************************************************");

                    Console.Write("Enter Your Choice Number Here: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 0:
                            Program.BackUP();
                            break;
                        case 1:
                            Program.AddRooms();
                            break;
                        case 2:
                            Program.DisplayRooms();
                            break;
                        case 3:
                            Program.AllocateRoom();
                            break;
                        case 4:
                            Program.DeAllocate();
                            break;
                        case 5:
                            Program.DisplayRoomAllocation();
                            break;
                        case 6:
                            Console.WriteLine("Billing Feature is Under Construction and will be added soon…!!!");
                            break;
                        case 7:
                            Program.SaveRoom();
                            break;
                        case 8:
                            Program.ShowRoom();
                            break;
                        case 9:
                            Console.WriteLine("You've Exited the file");
                            break;
                    }
                    Console.Write("\nWould You Like To Continue(Y/N):");
                    ans = Convert.ToChar(Console.ReadLine());
                } while (ans == 'y' || ans == 'Y') ;
            } 
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nException handled " + ex.Message);
            }

        }
    }
}
