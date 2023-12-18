using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Model;
namespace Service;

public class DataService
{
    private TrelloContext db { get; }

    public DataService(TrelloContext db)
    {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    
  public void SeedData()
{
    Board board = db.Boards.FirstOrDefault();
    if (board == null)
    {
        User user1 = new User("cornelius");
        User user2 = new User("christian");
        List<Todo> todos = new List<Todo>
        {
            new Todo("Hente øl", user1),
            new Todo("Lav lektier", user2)
        };
        db.AddRange(todos);
        db.SaveChanges();
    }
}

    

    public List<Board> GetBoards()
    {
        return db.Boards.Include(b => b.Todos).ThenInclude(t => t.User).ToList();
       
    }

    public Board GetBoard(int id)
    {
        return db.Boards.Include(b => b.BoardId).FirstOrDefault(b => b.BoardId == id);
    }

    public List<User> GetUsers()
    {
        return db.Users.ToList();
    }

    public User GetUser(int id)
    {
        return db.Users.Include(a => a.UserId).FirstOrDefault(a => a.UserId == id);
    }

    public string CreateBoard(Todo[] todos)
    {
        db.Add(new Board(todos.ToList()));
        db.SaveChanges();
        return "wuhu";
    }
    public string DeleteTodo(long id)
    {
        Todo todo = db.Todos.Find(id);
        db.Todos.Remove(todo);
        db.SaveChanges();
        return "Den er væk";
    }
}