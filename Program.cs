using System;
using System.Linq;
public class Program
{
	public static void Main(string[] args)
	{
		seedTasks();
	}
	public static void seedTasks()
	{
		using var db = new ProjectManager();
			
		// Note: This sample requires the database to be created before running.
		Console.WriteLine($"Database path: {db.DbPath}.");

		// Create
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
		// Read
		Console.WriteLine("Querying for a blog");
		var blog = db.Tasks
			.OrderBy(b => b.TaskId)
			.FirstOrDefault(blog => blog.TaskId == 1);

		

		//// Update
		//Console.WriteLine("Updating the blog and adding a post");
		//blog.Url = "https://devblogs.microsoft.com/dotnet";
		//blog.Posts.Add(
		//    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
		//db.SaveChanges();

		//// Delete
		//Console.WriteLine("Delete the blog");
		//db.Remove(blog);
		//db.SaveChanges();


	}
}