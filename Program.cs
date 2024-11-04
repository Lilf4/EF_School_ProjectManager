using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
public class Program
{
	public static void Main(string[] args)
	{
		printIncompleteTasksAndTodos();
	}

	public static void  printIncompleteTasksAndTodos(){
		using var db = new ProjectManager();
		var tasks = db.Tasks
			.Where(task => task.Todos.Any(todo => !todo.IsComplete))
			.Include(task => task.Todos.Where(todo => !todo.IsComplete));
		foreach(Task task in tasks){
			Console.Write(task.TaskId);
			Console.Write(" | ");
			Console.WriteLine(task.Name);
			foreach(Todo todo in task.Todos){
				Console.Write(todo.TodoId);
				Console.Write(" | ");
				Console.Write(todo.Name);
				Console.Write(" | ");
				Console.WriteLine(todo.IsComplete);
			}
			Console.WriteLine("-------");
		}

	}
	public static void seedTasks()
	{
		using var db = new ProjectManager();
			
		Console.WriteLine($"Database path: {db.DbPath}.");

		Console.WriteLine("Inserting a new blog");
		Task softwareTask = new Task(){Name = "Produce software"};
		softwareTask.Todos.AddRange([
			new Todo(){Name = "Write code"}, 
			new Todo(){Name = "Compile source"}, 
			new Todo(){Name = "Test program"}]);
		db.Add(softwareTask);
		db.SaveChanges();

		Task coffeTask = new Task(){Name = "Brew coffe"};
		coffeTask.Todos.AddRange([
			new Todo(){Name = "Pour water"}, 
			new Todo(){Name = "Pour coffee"}, 
			new Todo(){Name = "Turn on"}]);
		db.Add(coffeTask);
		db.SaveChanges();
	}
}