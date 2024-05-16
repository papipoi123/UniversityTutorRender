using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Role)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Admin)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.AdminId);

            builder.HasOne(x => x.Student)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.StudentId);

            builder.HasOne(x => x.Tutor)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.TutorId);

            builder.HasOne(x => x.Wallet)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.WalletId);
        }
    }
}
