using SOSPets.Domain.Models;

namespace SOSPets.ViewModel.Session
{
    public class UserViewModelInput
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UID { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public AddressViewModelInput Address { get; set; }
        public ContactViewModelInput? Contact { get; set; }
    }
}
