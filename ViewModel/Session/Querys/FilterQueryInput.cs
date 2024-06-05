using SOSPets.Domain.Models.Enums;

namespace SOSPets.ViewModel.Session.Querys;

public class FilterQueryInput
{
    public SizePetEnum? Size { get; set; }
    public StageLifeEnum? StageLife { get; set; }
    public TypePetEnum? Type { get; set; }
}