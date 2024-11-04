using Microsoft.EntityFrameworkCore;

public class ProjectManager : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<Worker> Worker { get; set; }
    public DbSet<TeamWorker> TeamWorker { get; set; }

    public string DbPath { get; }

    public ProjectManager()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "ProjectManager.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<TeamWorker>().HasKey(o => new {o.TeamId, o.WorkerId});
	}
}

public class Task
{
    public int TaskId { get; set; }
    public string Name { get; set; }

    public List<Todo> Todos { get; } = new();
}

public class Todo
{
    public int TodoId { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}

public class Team{
	public int TeamId {get; set;}
	public string Name {get; set;}
	public List<Worker> Workers {get;} = new();
}

public class Worker{
	public int WorkerId {get; set;}
	public string Name {get; set;}
	public List<Team> Teams {get;} = new();
}

public class TeamWorker{
	public int TeamId {get; set;}
	public Team Team {get; set;}
	public int WorkerId {get; set;}
	public Worker Worker {get; set;}
}