//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.EntityFrameworkCore;

namespace ProblemAnalysis2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invitation>()
                .Property(inv => inv.Status)
                .HasConversion<string>(); 
        }
    }
}
