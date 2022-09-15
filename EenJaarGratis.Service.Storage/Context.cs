using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<QuestionGroup> QuestionGroups { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .Property(q => q.PointsToShare)
                .HasDefaultValue(100);
        }
    }
}