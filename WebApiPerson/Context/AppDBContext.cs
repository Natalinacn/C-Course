using Microsoft.EntityFrameworkCore;
using University.Models;
using WebApiPerson.Models;

namespace WebApiPerson.Context
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
            
        }

        //Add DbSets (Tables of out Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }

    }

}
