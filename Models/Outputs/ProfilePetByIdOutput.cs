using SOSPets.Domain.Models.Enums;

namespace SOSPets.Models.Outputs;

public class ProfilePetByIdOutput
{
    public string UidUser { get; set; }
    public string NameUser { get; set; }
    public string NamePet { get; set; }
    public SizePetEnum Size { get; set; }
    public StageLifeEnum StageLife { get; set; }
    public TypePetEnum TypePet { get; set; }
    public string? Description { get; set; }
    public string? UrlPhotoPetMain { get; set; }
    public List<string>? Photos { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public ProfilePetByIdOutput(string uidUser, string nameUser, string namepet, SizePetEnum size, StageLifeEnum stageLife, TypePetEnum typePet, string? description, string? urlPhotoProfilePet, List<string> photos, double lat, double longi)
    {
        UidUser = uidUser;
        NameUser = nameUser;
        NamePet = namepet;
        Size = size;
        StageLife = stageLife;
        TypePet = typePet;
        Description = description;
        UrlPhotoPetMain = urlPhotoProfilePet;
        Photos = new List<string>(photos);
        Latitude = lat;
        Longitude = longi;
    }


}