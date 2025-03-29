namespace taskManager_BusinessLogic
{
    public class process
    {
        public static string[] tasks = new string[100];
        public static bool[] taskStatus = new bool[100];
       public  static int taskCount = 0;

        public static void SaveTask(string task)
        {
            tasks[taskCount] = task;
            taskStatus[taskCount] = false;
            taskCount++;
        }

        public static bool IsValidTaskNumber(int taskNum)
        {
            return taskNum > 0 && taskNum <= taskCount;
        }

        public static void RemoveTask(int index)
        {
            for (int i = index; i < taskCount - 1; i++)
            {
                tasks[i] = tasks[i + 1];
                taskStatus[i] = taskStatus[i + 1];
            }
            taskCount--;
        }

    }
}
