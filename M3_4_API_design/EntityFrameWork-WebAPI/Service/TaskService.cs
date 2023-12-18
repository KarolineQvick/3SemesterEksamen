using System;
using Microsoft.EntityFrameworkCore;
using Model;
namespace Service
{
	public class TaskService 
	{
		private TaskContext db { get; }

		public TaskService(TaskContext db)
		{
			this.db = db;
		}


        public void SeedData()
        {
            Board board = db.Boards.FirstOrDefault();
            if (board == null)
            {
                Console.WriteLine("Indsæt noget nyt");
                User testUser = new User("Cornelius");
              
                TodoTask testTodo0 = new TodoTask("Købe ind", false, "Hus", testUser);
                TodoTask testTodo1 = new TodoTask("vasketøj", false, "Hus", testUser);
                TodoTask testTodo2 = new TodoTask("male", false, "Hus", testUser);
                Board testBoard = new Board();

                // Tilføjer TodoTask til Board-liste

                testBoard.Todos.Add(testTodo0);
                testBoard.Todos.Add(testTodo1);
                testBoard.Todos.Add(testTodo2);

                db.Add(testBoard);
                db.SaveChanges();
            }

        }

        // GET Todoliste på ID

        public List<TodoTask> GetTodoTasks()
        {
            return db.Tasks.ToList();
        }

        // GET alle Todos på specifik Board

        public List<TodoTask> GetBoardTasks(int id)
        {
            return db.Boards.Include(t => t.Todos).ThenInclude(u => u.User).First(i => i.BoardId == id).Todos;
           
        }

        public User GetUser(int id)
        {
            return db.Users.First(u => u.UserId == id);
        }

        // Opdaterer board på boardId med ny TodoTask newTask og returnere newTask. 
        public TodoTask CreateTask (TodoTask newTask, int boardId)
        {
            db.Boards.First(b => b.BoardId == boardId).Todos.Add(newTask);
            db.SaveChanges();
            return newTask;
        }



    }





    
}

