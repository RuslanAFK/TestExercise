using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestExercise.Domain.Models;

namespace TestExercise.Data.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.AccountId);
        builder.HasIndex(a => a.AccountName)
            .IsUnique();
        builder.HasOne<Incident>()
            .WithMany(i => i.Accounts)
            .HasForeignKey(a => a.IncidentName);

        var defaultAccount = new Account()
        {
            AccountId = 1,
            AccountName = "ruslan"
        };
        builder.HasData(defaultAccount);
    }
}
