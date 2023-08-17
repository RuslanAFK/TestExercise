using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestExercise.Domain.Models;

namespace TestExercise.Data.EntityConfigurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.ContactId);
        builder.HasIndex(c => c.Email)
            .IsUnique();
    }
}
