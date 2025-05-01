using System;

class Program{
    static void Main(string[] args){

        //creates a list of strings for tasks to be stored in
        List<string> tasks = new List<string>();



        if (File.Exists("tasks.txt"))
            tasks = new List<string>(File.ReadAllLines("tasks.txt"));
       
       //used for loop so users can revisit main menu until they are done managing their list
        bool running = true;
        Console.WriteLine("Welcome to the To-Do List App!");

        //menu loop that asks users what they want to do until they exit
        while(running){
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove a task");
            Console.WriteLine("4. Mark task done");
            Console.WriteLine("5. Sort task alphabetically");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
            //takes in users choice
            string input = Console.ReadLine();

            switch(input){

                //if user decides 1, they can add task to their list
                case "1":
                    Console.WriteLine("Enter a new task: ");
                    string task = Console.ReadLine();
                    tasks.Add(task);
                    SaveTasks(tasks);
                    Console.WriteLine("Task Added!");
                    break;

                //if user decides 2, they can view their tasks, if there are no tasks, program returns "error' message
                case "2":
                    Console.WriteLine("\n Your Tasks: ");
                    if (tasks.Count == 0)
                        Console.WriteLine("(No tasks yet)");
                    else
                        for(int i = 0; i<tasks.Count; i++)
                            Console.WriteLine($"{i+1}. {tasks[i]}");
                    break;

                
                //case 3 allows users to remove a task of their choice using the number of the task
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


                //if users choose 4, task gets marked as complete, returns error if task number doesn't exist
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


                //sorts tasks in alphabetical order
                case "5":
                    tasks.Sort();
                    Console.WriteLine("Tasks Sorted");
                    break;


                //turns running bool false, user exits and gets a goodbye message
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye");
                    break;

                //if user enters an invalid choice#, program breaks & gives error message then user is prompted again
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    //method that saves tasks to a file
    static void SaveTasks (List<string> tasks){
        File.WriteAllLines("tasks.txt", tasks);
    }
}

