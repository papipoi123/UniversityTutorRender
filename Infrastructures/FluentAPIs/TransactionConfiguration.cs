using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AmountTransaction)
                   .HasColumnType("money");

            builder.HasOne(x => x.Wallet)
                   .WithMany(x => x.Transactions)
                   .HasForeignKey(x => x.WalletId);
        }
    }
}
