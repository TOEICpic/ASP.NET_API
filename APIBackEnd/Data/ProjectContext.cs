using APIBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBackEnd.Data
{
    public class ProjectContext : DbContext
    {
        //Constructor
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public ProjectContext() { }

        public DbSet<tableLeagues> tableLeagues { get; set; }
        public DbSet<tableLeagues> tableTime { get; set; }
        public DbSet<tableLeagues> tableMatch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping + จัดการ relations
            modelBuilder.Entity<tableLeagues>().ToTable("tableLeagues");
            modelBuilder.Entity<tableTime>().ToTable("tableTime");
            modelBuilder.Entity<tableMatch>().ToTable("tableMatch");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "localhost";
            string database = "project";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";PORT=3306;SslMode=Required;";
            optionsBuilder.UseMySQL(connectionString);
        }
        public DbSet<APIBackEnd.Models.tableMatch> tableMatch_1 { get; set; } = default!;
        public DbSet<APIBackEnd.Models.tableTime> tableTime_1 { get; set; } = default!;
    }
}
