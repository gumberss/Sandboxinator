using Attendance.Proposals.Configurations.Configurations;
using Attendance.Proposals.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Attendance.Proposals.Data.Contexts
{
    public class ProposalContext : DbContext
    {
        private readonly IOptions<EnvironmentConfig> _config;

        public DbSet<Proposal> Proposals { get; set; }

        public ProposalContext(IOptions<EnvironmentConfig> config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config?.Value?.DbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            System.Console.WriteLine(_config);
        }
    }
}
