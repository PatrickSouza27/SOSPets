using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSPets.Domain.Models;

namespace SOSPets.Data.Mapping
{
    public class ProfilePetMap : IEntityTypeConfiguration<ProfilePet>
    {
        public void Configure(EntityTypeBuilder<ProfilePet> builder)
        {
            builder.ToTable("ProfilePet");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasColumnType("integer");


            builder.Property(x => x.UrlPhotoProfile)
                .HasColumnName("urlPhotoProfile")
                .HasColumnType("nvarchar")
                .HasMaxLength(260);


            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(160);

            builder.Property(x => x.SizePet)
                .HasColumnName("sizePet")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);


            builder.Property(x => x.StageLife)
                .HasColumnName("stageLife")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);

            builder.Property(x => x.TypePet)
                .HasColumnName("typePet")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);


            builder.Property(x => x.DateCreatedProfile)
                .HasColumnName("dateCreatedProfile")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);


            builder.HasOne(u => u.ProfileUser)
                .WithMany(x => x.ProfilesPet)
                .HasForeignKey(u => u.Fk_profile)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
