using Microsoft.EntityFrameworkCore;

namespace EntityLayer.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // public DbSet<User> Users { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<OrganizationRegistryInfo> Organizations { get; set; }
        public virtual DbSet<OrganizationBranchRegistryInfo> OrganizationBranches { get; set; }
        public virtual DbSet<AdminDepartment> Departments { get; set; }
        public virtual DbSet<AdminDesignation> Designations { get; set; }
    }
}