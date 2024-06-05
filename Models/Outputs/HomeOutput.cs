namespace SOSPets.Models.Outputs
{
    public class HomeOutput
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PhotoUser { get; set; }
        public string NameUser { get; set; }
        public int IdProfilePet { get; set; }
        public string? PhotoProfilePet { get; set; }
        public string UidUser { get; set; }
        public HomeOutput() { }
        public HomeOutput(string title, string? description, string? photoUser, string nameUser, int idProfilePet, string? photoProfilePet, string uidUser)
        {
            Title = title;
            Description = description;
            PhotoUser = photoUser;
            NameUser = nameUser;
            IdProfilePet = idProfilePet;
            PhotoProfilePet = photoProfilePet;
            UidUser = uidUser;
        }
    }
}
