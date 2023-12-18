using System;
// TodoTask.cs
namespace Model
{
    public class TodoTask
    {
        public TodoTask(string text, bool done)
        {
            this.Text = text;
            this.Done = done;
        }

        public TodoTask(string text, bool done, string category, User user)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
            this.User = user;
        }

        public TodoTask()
        {

        }




        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
        public string? Category { get; set; }
        public User? User { get; set; }

    }
}
