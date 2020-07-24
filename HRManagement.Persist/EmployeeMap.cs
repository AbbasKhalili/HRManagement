using HRManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Persist
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.EmployeeNumber);
            builder.Property(t => t.Firstname);
            builder.Property(t => t.Lastname);
            builder.Property(t => t.Age);

            builder.HasMany(x => x.Languages).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
        }

    }
}