using Microsoft.EntityFrameworkCore;

namespace todo_API.Models
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<Task> Task { get; set; }
    }
}
