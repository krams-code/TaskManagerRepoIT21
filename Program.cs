using System;
using System.Diagnostics;
using taskManager_BusinessLogic;

namespace Project
{
    namespace taskManager
    {
        internal class Program
        {
           static  BusinessLogic_Process blProcess = new BusinessLogic_Process(); 

            static void Main(string[] args)
            {
                Console.WriteLine("==== ADMIN LOGIN ====");

                const string adminUsername = "user";
                const string adminPassword = "123";

                int loginAttempts = 3;

                while (loginAttempts > 0)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    if (blProcess.validateAccount(username, password))
                    {
                        Console.WriteLine("\nLogin successful!\n");
                        Users(username, password);
                        break;
                    }
                    else
                    {
                        loginAttempts--;
                        Console.WriteLine($"Invalid credentials. Attempts left: {loginAttempts}\n");

                        if (loginAttempts == 0)
                        {
                            Console.WriteLine("Too many failed attempts. Exiting program...");
                            return;
                        }
                    }
                }

                
                
            }
            public static void Users(string username, string password)
            {
                Console.WriteLine("WELCOME TO MY TASK MANAGER");

                while (true)
                {
                    DisplayMenu();
                    int userAction = GetUserInput();

                    switch (userAction)
                    {
                        case 1:
                            AddTask(username);
                            break;
                        case 2:
                            ViewTasks(username);
                            break;
                        case 3:
                            MarkTaskAsCompleted(username);
                            break;
                        case 4:
                            DeleteTask(username);
                            break;
                        case 5:
                            Console.WriteLine("Exiting Task Manager...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
            }
            // UI Layer
            static void DisplayMenu()
            {
                Console.WriteLine("\nACTIONS:");
                Console.WriteLine("[1] Add Task");
                Console.WriteLine("[2] View Tasks");
                Console.WriteLine("[3] Mark Task as Completed");
                Console.WriteLine("[4] Delete Task");
                Console.WriteLine("[5] Exit");
                Console.Write("Enter Action: ");
            }

            static int GetUserInput()
            {
                int userAction;
                if (int.TryParse(Console.ReadLine(), out userAction))
                {
                    return userAction;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return 0;
                }
            }

            static void AddTask(string username)
            {
                Console.Write("Enter Task: ");
                string task = Console.ReadLine();
                if(blProcess.task(username, task))
                Console.WriteLine("Task added successfully!");
            }

            static void ViewTasks(string username)
            {
                    Console.WriteLine("\nTASK LIST:");
                    string tasks = blProcess.GetTask(username);
                Console.WriteLine(tasks);
            }


            static void MarkTaskAsCompleted(string username)
            {
                Console.Write("Enter task number to mark as completed: ");
                int taskNum = GetUserInput();
                

                if (blProcess.UpdateTask(taskNum, username))
                {

                    Console.WriteLine("Task Update successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }

            static void DeleteTask(string username)
            {
                Console.Write("Enter task number to delete: ");
                int taskNum = GetUserInput();
               
                if (blProcess.DeleteTask(taskNum, username))
                {
                   
                    Console.WriteLine("Task deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }

            
        }
    }
}
