using SOSPets.Data.Repository.Interfaces;
using SOSPets.Domain.Models;

namespace SOSPets.Data.Repository
{
    public class AddressRepository : IDefaultRepository<Address>
    {
        private readonly List<Address> _addresses = new();
        public async Task<bool> CreateAsync(Address entity)
        {
            int count = _addresses.Count;
            _addresses.Add(entity);
            return count + 1 == _addresses.Count;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int count = _addresses.Count;
            _addresses.Remove(_addresses.Where(x => x.Id == id).First());
            return count - 1 == _addresses.Count;

        }

        public async Task<List<Address>> GetAllAsync()
        {
            return _addresses.ToList();
        }

        public async Task<bool> UpdateAsync(Address entity)
        {
            var address = _addresses.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (address != null)
            {
                address.Street = entity.Street;
                address.Number = entity.Number;
                address.City = entity.City;
                address.PostalCode = entity.PostalCode;
                address.Neighborhood = entity.Neighborhood;
                address.Complement = entity.Complement;
                return true;

            }

            return false;
        }
    }
}
