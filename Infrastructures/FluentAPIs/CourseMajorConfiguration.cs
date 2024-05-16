using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CourseMajorConfiguration : IEntityTypeConfiguration<CourseMajor>
    {
        public void Configure(EntityTypeBuilder<CourseMajor> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
