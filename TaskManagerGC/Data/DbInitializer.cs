using System;
using System.Linq;
using TaskManagerGC.Models;

namespace TaskManagerGC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.Add(new User() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Username = "David", FullName = "David Alyakobi", Email = "davidalyakobi@gmail.com" });
                context.Users.Add(new User() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Username = "GrandCircus", FullName = "Grand Circus" });
                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Task() {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Title = "C#.NET Technical Challenge: TASK LIST",
                    Description = "Task: Create a web-based task manager\n" +
                            "What Will the Application Do ?\n" +
                            "● The user can create a new task.Tasks consist of:\n" +
                            "o A task description\n" +
                            "o The due date\n" +
                            "o Whether it’s complete or not\n" +
                            "● The user should see a list of all tasks\n" +
                            "o There should be a button or checkbox  to mark the task complete\n" +
                            "o There should be a button to delete the task\n" +
                            "● For MVP, you do not need to provide user authentication or state\n" +
                            "     management--this can be a single task list shared across all users\n" +
                            "Build Specifications(Required)\n" +
                            "1.Build this as an MVC web application in .NET Core 3.1\n" +
                            "2.Store tasks in an MS SQL database table using Entity Framework\n" +
                            "3.Minimum views: Welcome page, task list, add task view\n" +
                            "Extended Challenges(Optional)\n" +
                            "● Let the user edit tasks beyond completeness\n" +
                            "● Let the user search for a task by a word or words in the description\n" +
                            "● Let the user sort or filter by due date",
                    Completed = true,
                    DueDate = new DateTime(2021, 10, 24)
                });

                context.Tasks.Add(new Task() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Title = "Create a new Task", Description = "Click Add Task\n Add Title/Description/DueDate", Completed = false });
                
                context.Tasks.Add(new Task() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Title = "Enjoy Life", Description = "Have a good day!", Completed = false, DueDate = new DateTime(2021, 11, 13) });
                context.SaveChanges();
            }
        }
    }
}
