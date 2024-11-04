using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
public class Program
{
	public static void Main(string[] args)
	{
		//seedTasks();
		//seedWorkers();
		using(var db = new ProjectManager()){
			var teams = db.Team.Include(team => team.AssignedTasks).Include(team => team.CurrentTask);
			var team = teams.First();
			team.AssignedTasks.Add(db.Tasks.First());
			team.CurrentTask = db.Tasks.First();
			db.Update(team);
			db.SaveChanges();
		}
		printIncompleteTasksAndTodos();
		PrintTeamsWithoutTasks();
	}

	public static void PrintTeamsWithoutTasks(){
		using var db = new ProjectManager();

		var teams = db.Team
			.Where(team => team.CurrentTask.Equals(null) && team.AssignedTasks.Count <= 0);
		
		foreach(Team team in teams){
			Console.WriteLine(team.Name);
		}
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

	public static void seedWorkers(){
		using var db = new ProjectManager();

		Team frontend = new Team(){
			Name = "Frontend"
		};
		Team backend = new Team(){
			Name = "Backend"
		};
		Team testere = new Team(){
			Name = "Testere"
		};

		Worker steen = new Worker(){
			Name = "Steen Secher"
		};
		Worker ejvind = new Worker(){
			Name = "Ejvind Møller"
		};
		Worker konrad = new Worker(){
			Name = "Konrad Sommer"
		};
		Worker sofus = new Worker(){
			Name = "Sofus Lotus"
		};
		Worker remo = new Worker(){
			Name = "Remo Lademann"
		};
		Worker ella = new Worker(){
			Name = "Ella Fanth"
		};
		Worker anne = new Worker(){
			Name = "Anne Dam"
		};

		db.Add(new TeamWorker(){Team = frontend, Worker = steen});
		db.Add(new TeamWorker(){Team = frontend, Worker = ejvind});
		db.Add(new TeamWorker(){Team = frontend, Worker = konrad});
		db.Add(new TeamWorker(){Team = backend, Worker = konrad});
		db.Add(new TeamWorker(){Team = backend, Worker = sofus});
		db.Add(new TeamWorker(){Team = backend, Worker = remo});
		db.Add(new TeamWorker(){Team = testere, Worker = ella});
		db.Add(new TeamWorker(){Team = testere, Worker = anne});
		db.Add(new TeamWorker(){Team = testere, Worker = steen});
		db.SaveChanges();
	}
}