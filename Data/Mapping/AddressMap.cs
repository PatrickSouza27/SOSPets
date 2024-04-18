using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSPets.Domain.Models;

namespace SOSPets.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer");


            builder.Property(x => x.Neighborhood)
                .IsRequired()
                .HasColumnName("neighborhood")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);


            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnName("city")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);

            builder.Property(x => x.Street)
                .IsRequired()
                .HasColumnName("street")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);


            builder.Property(x => x.Number)
                .IsRequired();




        }
    }
}
