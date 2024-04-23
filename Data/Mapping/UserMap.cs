using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSPets.Domain.Models;

namespace SOSPets.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer");


            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(60);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("lastName")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);


            builder.HasOne(u => u.Fk_Address)
                .WithOne()
                .HasForeignKey<Address>(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
