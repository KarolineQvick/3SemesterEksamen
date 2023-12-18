
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class TrelloContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Todo> Todos{ get; set; }

       

        public string DbPath { get; }

        public TrelloContext(DbContextOptions<TrelloContext> options)
             : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }

   
    }
}




