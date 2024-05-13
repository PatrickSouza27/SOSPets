namespace SOSPets.Services.Interface
{
    public interface IS3Service
    {
        Task<string> SaveImageAsync(string base64Image, string folder);
    }
}
