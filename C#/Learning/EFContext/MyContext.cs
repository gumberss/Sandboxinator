using Learning.Threads.BusinessRules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Learning
{
    public class MyContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(@"Server=DESKTOP-UVC3FPE\SQLEXPRESS;Database=Learning;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
