using Microsoft.EntityFrameworkCore;

namespace ArtSystemApp.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Confirmation> Confirmations { get; set; }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Format> Formats { get; set; }

        public DbSet<Work> Works { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Folder> Folders { get; set; }



    public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=artsystemdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role userRole = new() { Id = 1, Name = "admin" };
            Role adminRole = new() { Id = 2, Name = "user" };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });

            Status activeStatus = new() { Id = 1, Name = "active" };
            Status blockStatus = new() { Id = 2, Name = "block" };
            modelBuilder.Entity<Status>().HasData(new Status[] { blockStatus, activeStatus });

            Confirmation freeConfirmation = new() { Id = 1, Name = "free" };
            Confirmation paidConfirmation = new() { Id = 2, Name = "paid" };
            modelBuilder.Entity<Confirmation>().HasData(new Confirmation[] { freeConfirmation, paidConfirmation });

            base.OnModelCreating(modelBuilder);
        }
    }



}
