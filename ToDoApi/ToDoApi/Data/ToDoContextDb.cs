using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoApi.Model;
using Microsoft.Extensions.Configuration;

namespace ToDoApi.Data
{
    public class ToDoContextDb : DbContext
    {
        public virtual DbSet<Model.User> User { get; set; }
        public virtual DbSet<Model.TaskToDo> Task{ get; set; }

        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.TaskToDo>(entity =>
            {
                entity.HasKey(e => e.idTask);
                entity.Property(e => e.description).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.idUser);
                entity.Property(e => e.name).IsRequired();
            });
        }

    }
}
