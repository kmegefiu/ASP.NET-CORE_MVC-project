using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class ApplicationDBContext:DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 
    }
}
