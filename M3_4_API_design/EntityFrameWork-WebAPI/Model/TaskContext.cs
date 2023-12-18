using System;
// TaskContext.cs
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class TaskContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet <Board> Boards { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
           // DbPath = "bin/TodoTask.db";
        }

        /* protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
            modelBuilder.Entity<Board>().ToTable("Boards");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
