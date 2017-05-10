namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModelContext : DbContext
    {
        public DbModelContext()
            : base("name=DbModelContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTitle>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.JobTitle)
                .WillCascadeOnDelete(false);
        }
    }
}
