using System;
using System.Diagnostics;
using taskManager_BusinessLogic;

namespace Project
{
    namespace taskManager
    {
        internal class Program
        {
            

            static void Main(string[] args)
            {
                Console.WriteLine("WELCOME TO MY TASK MANAGER");

                while (true)
                {
                    DisplayMenu();
                    int userAction = GetUserInput();

                    switch (userAction)
                    {
                        case 1:
                            AddTask();
                            break;
                        case 2:
                            ViewTasks();
                            break;
                        case 3:
                            MarkTaskAsCompleted();
                            break;
                        case 4:
                            DeleteTask();
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

            static void AddTask()
            {
                Console.Write("Enter Task: ");
                string task = Console.ReadLine();
                process.SaveTask(task);
                Console.WriteLine("Task added successfully!");
            }

            static void ViewTasks()
            {
                if (process.taskCount == 0)
                {
                    Console.WriteLine("No tasks available.");
                }
                else
                {
                    Console.WriteLine("\nTASK LIST:");
                    for (int i = 0; i < process.taskCount; i++)
                    {
                        if (process.taskStatus[i])
                        {
                            Console.WriteLine((i + 1) + ". [Completed] " + process.tasks[i]);
                        }
                        else
                        {
                            Console.WriteLine((i + 1) + ". [Pending] " + process.tasks[i]);
                        }
                    }
                }
            }


            static void MarkTaskAsCompleted()
            {
                Console.Write("Enter task number to mark as completed: ");
                int taskNum = GetUserInput();

                if (process.IsValidTaskNumber(taskNum))
                {
                    process.taskStatus[taskNum - 1] = true;
                    Console.WriteLine("Task marked as completed!");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }

            static void DeleteTask()
            {
                Console.Write("Enter task number to delete: ");
                int taskNum = GetUserInput();

                if (process.IsValidTaskNumber(taskNum))
                {
                    process.RemoveTask(taskNum - 1);
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
