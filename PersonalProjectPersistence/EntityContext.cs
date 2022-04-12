using Microsoft.EntityFrameworkCore;
using PersonalProfileDomain.Entitys;

namespace PersonalProfilePersistence.Context
{
    public class EntityContext : DbContext
    {
        public DbSet<Personal> Me { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Exprience> Expriences { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public EntityContext()
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            modelBuilder.Entity<Skill>().HasKey(t => t.ID);
            modelBuilder.Entity<User>().Property(t => t.FullName).IsRequired();
            modelBuilder.Entity<User>().Property(t => t.PhoneNumber).IsRequired();
            modelBuilder.Entity<User>().Property(t => t.Email).IsRequired();
            modelBuilder.Entity<Personal>().Property(t => t.FullName).IsRequired();
            modelBuilder.Entity<Personal>().Property(t => t.PhoneNumber).IsRequired();
            modelBuilder.Entity<Personal>().Property(t => t.Email).IsRequired();
            modelBuilder.Entity<Skill>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<Skill>().Property(t => t.Percent).IsRequired();
            modelBuilder.Entity<Exprience>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<Exprience>().Property(t => t.Subject).IsRequired();
            modelBuilder.Entity<Exprience>().Property(t => t.Description).IsRequired();
        }
    }
}