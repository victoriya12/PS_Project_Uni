using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace UserLogin
{
    internal class Program
    {
        public static void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Username: ");
            string username=Console.ReadLine();
            Console.Write("Enter Password: ");
            string password=Console.ReadLine();
            
            LoginValidation loginValidation = new LoginValidation(username,password,ActionOnError);

            User user = null;

            if (loginValidation.ValidateUserInput(ref user))
            {
                
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Password: " + user.Password);
                Console.WriteLine("Faculty number: " + user.FakNum);
                Console.WriteLine("Role: " + user.Role);



                switch (Convert.ToInt32(LoginValidation.CurrentUserRole))
                {
                    case 0:
                        Console.WriteLine("Роля: Анонимен");
                        break;
                    case 1:
                        Console.WriteLine("Роля: Админ");

                        Boolean menu = true;
                        while (menu)
                        {
                            menu = adminMenu();
                        }

                        break;
                    case 2:
                        Console.WriteLine("Роля: Инспектор");
                        break;
                    case 3:
                        Console.WriteLine("Роля: Професор");
                        break;
                    case 4:
                        Console.WriteLine("Роля: Студент");
                        break;
                }
            


            }

        }
        private static Boolean adminMenu()
        {
            string username;
            Console.WriteLine("Меню на роля: Админ");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребители");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");
            Console.WriteLine("Изберете опция: ");
            Int32 choice=Console.ReadLine().Length;
            switch (choice)
            {
                case 0:
                    return false;
                  

                case 1:
                    Console.WriteLine("Потребителско име на потребител за промяна:");
                    username = Console.ReadLine();

                    Console.WriteLine("Нова роля на този потребител: ");
                    UserRoles role = (UserRoles)Convert.ToInt32(Console.ReadLine());

                    UserData.AssignUserRole(username, role);
                    return true;
                  

                case 2:
                    Console.WriteLine("Потребителско име на потребител за промяна:");
                    username = Console.ReadLine();

                    Console.Write("Нова дата на този потребител: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());

                    UserData.SetUserActiveTo(username, date);

                    return true;

                  

                case 3:
                    for (int i = 0; i < UserData.testUsers.Count; i++)
                    {
                        Console.WriteLine(UserData.testUsers[i]);
                    }

                    return true;
                   
                case 4:
                 
                    //StringBuilder sb = new StringBuilder();
                    //IEnumerable <string> logActivity = Logger.GetCurrentSessionActivities();
                    //foreach (string log in logActivity)
                    //{
                    //    sb.Append(log).Append(Environment.NewLine);
                    //}
                    //Console.WriteLine(sb.ToString());
                    //return true;
                    

                case 5:
                    StringBuilder build = new StringBuilder();
                    Console.Write("Въведете филтъра: ");
                    string filter = Console.ReadLine();
                    IEnumerable<string> activities = Logger.GetCurrentSessionActivities(filter);

                    foreach (string message in activities)
                    {
                        build.Append(message).Append(Environment.NewLine);
                    }

                    Console.Write(build.ToString());
                    return true;


                default:
                    return true;


            }

        }


    }
}
