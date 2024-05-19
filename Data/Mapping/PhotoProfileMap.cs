using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSPets.Domain.Models;

namespace SOSPets.Data.Mapping
{
    public class PhotoProfileMap : IEntityTypeConfiguration<PhotoProfilePet>
    {
        public void Configure(EntityTypeBuilder<PhotoProfilePet> builder)
        {
            builder.ToTable("PhotoProfile");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer");


            builder.Property(x => x.DatePost)
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


            //builder.HasOne(u => u.ProfilePet)
            //    .WithMany(x => x.PhotosProfilePet)
            //    .HasForeignKey(u => u.ProfilePet)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
