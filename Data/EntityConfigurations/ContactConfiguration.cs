using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.ContactId);
        builder.HasIndex(c => c.Email)
            .IsUnique();
        builder.HasOne<Account>()
            .WithMany(a => a.Contacts)
            .HasForeignKey(c => c.AccountId);

    }
}
