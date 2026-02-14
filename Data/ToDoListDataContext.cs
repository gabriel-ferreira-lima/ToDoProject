using Microsoft.EntityFrameworkCore;
using TodoList.Data.Mappings;
using TodoList.Models;

namespace TodoList.Data {
    public class ToDoListDataContext : DbContext{
        public ToDoListDataContext(DbContextOptions<ToDoListDataContext> options) : base(options) {
        }
        
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new ToDoMap());
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
