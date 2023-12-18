using System;
namespace Model
{
	public class Board
	{
		public int BoardId { get; set; }
		public List<TodoTask> Todos { get; set; } = new List<TodoTask>();


		public Board()
		{
			
		}
	}
}

