using HRManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Persist
{
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Level);
            builder.Property(t => t.LanguageName);
            builder.Property(t => t.EmployeeId);
        }

    }
}