using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RazorPagesSoccer.Models.Mappings
{
    public class ClubMapping : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable("Club");

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Founding)
                .IsRequired();
        }
    }
}
