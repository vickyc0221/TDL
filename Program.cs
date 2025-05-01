// See https://aka.ms/new-console-template for more information
using System;

class Program{
    static void Main(string[] args){

        List<string> tasks = new List<string>();

        if (File.Exists("tasks.txt"))
            tasks = new List<string>(File.ReadAllLines("tasks.txt"));
       
        bool running = true;
        Console.WriteLine("Welcome to the To-Do List App!");

        while(running){
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove a task");
            Console.WriteLine("4. Mark task done");
            Console.WriteLine("5. Sort task alphabetically");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
            string input = Console.ReadLine();

            switch(input){
                case "1":
                    Console.WriteLine("Enter a new task: ");
                    string task = Console.ReadLine();
                    tasks.Add(task);
                    SaveTasks(tasks);
                    Console.WriteLine("Task Added!");
                    break;

                case "2":
                    Console.WriteLine("\n Your Tasks: ");
                    if (tasks.Count == 0)
                        Console.WriteLine("(No tasks yet)");
                    else
                        for(int i = 0; i<tasks.Count; i++)
                            Console.WriteLine($"{i+1}. {tasks[i]}");
                    break;
                
                case "3":
                    Console.WriteLine("Enter task number to remove: ");
                    int index;
                    if(int.TryParse(Console.ReadLine(), out index) && index>=1){
                        Console.WriteLine($"Removed: {tasks[index-1]}");
                        tasks.RemoveAt(index-1);
                    }
                    else {
                        Console.WriteLine("Invalid task number");
                    }
                    break;

                case "4":
                    Console.WriteLine("Enter task number to mark as done: ");
                    if (int.TryParse(Console.ReadLine(), out index) && index>=1 && index <=tasks.Count){
                        if(tasks[index-1].StartsWith("---")){
                            Console.WriteLine("Task already marked as done.");

                        }
                        else {
                            tasks[index-1] = "---" + tasks[index-1];
                            Console.WriteLine("Task marked as done!");
                        }
                    }
                    else{
                        Console.WriteLine("Invalid task number.");
                    }
                    break;

                case "5":
                    tasks.Sort();
                    Console.WriteLine("Tasks Sorted");
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Goodbye");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void SaveTasks (List<string> tasks){
        File.WriteAllLines("tasks.txt", tasks);
    }
}

