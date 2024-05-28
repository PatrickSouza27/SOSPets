using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSPets.Domain.Models;

namespace SOSPets.Data.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer");


            builder.Property(x => x.DateCreated)
                .HasColumnName("dateCreated")
                .HasColumnType("DATETIME");


            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar")
                .HasMaxLength(160);

            builder.Property(x => x.UrlPhoto)
                .HasColumnName("urlPhoto")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);

            builder.HasOne(u => u.User)
                .WithOne(x=> x.Profile)
                .HasForeignKey<Profile>(u => u.Fk_user)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
