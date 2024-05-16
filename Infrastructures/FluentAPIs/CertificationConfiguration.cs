using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CertificationConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Tutor)
                   .WithMany(x => x.Certifications)
                   .HasForeignKey(x => x.TutorId);
        }
    }
}
