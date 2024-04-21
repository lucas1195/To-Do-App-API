using Microsoft.EntityFrameworkCore;

namespace todo_API.Models
{
    public class Contexto : DbContext
    {
        public Contexto( DbContextOptions<Contexto> options): base(options) 
        { 
        }

        public DbSet<Task> Task { get; set; }
    }
}
