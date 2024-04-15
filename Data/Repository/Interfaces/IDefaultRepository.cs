namespace SOSPets.Data.Repository.Interfaces
{
    public interface IDefaultRepository <T> where T : class
    {
        Task<bool> CreateAsync (T entity);
        Task<bool> UpdateAsync (T entity);
        Task<bool> DeleteAsync (int id);
        Task<List<T>> GetAllAsync ();
    }
}
