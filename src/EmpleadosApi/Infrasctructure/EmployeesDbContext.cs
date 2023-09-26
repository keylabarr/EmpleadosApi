using EmpleadosDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosApi.Infrasctructure
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        protected readonly IConfiguration Configuration;

        
       
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options, IConfiguration configuration) : base(options) 
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "OptimissaDB");
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("EmployeesDb"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(p => p.Id);
        }
    }
}
