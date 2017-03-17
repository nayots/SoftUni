namespace SoftUniQueries
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class SoftUniContext : DbContext
    {
        public SoftUniContext()
            : base("name=SoftUniContext")
        {

        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.AddressText)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.ManagerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeesProjects").MapLeftKey("EmployeeID").MapRightKey("ProjectID"));

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Town>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }

        public ICollection<Project> GetProjects(string firstName, string lastName)
        {
           //This is the procedure used
            /*
            CREATE PROCEDURE usp_GetProjectsByEmployee(@FirstName NVARCHAR(255), @LastName NVARCHAR(255))
            AS
            BEGIN


                SELECT p.*
                FROM Employees AS e
                INNER JOIN EmployeesProjects AS ep

                ON ep.EmployeeID = e.EmployeeID

                INNER JOIN Projects AS p
                ON p.ProjectID = ep.ProjectID
                WHERE LOWER(e.FirstName) = LOWER(@FirstName) AND LOWER(e.LastName) = LOWER(@LastName)
            END
             */

            string query = @"EXEC usp_GetProjectsByEmployee @FirstName, @LastName";

            SqlParameter firstN = new SqlParameter("@FirstName", firstName);
            SqlParameter LastN = new SqlParameter("@LastName", lastName);

            var projects = Database.SqlQuery<Project>(query, firstN, LastN).ToList();

            return projects;
        }
    }
}
