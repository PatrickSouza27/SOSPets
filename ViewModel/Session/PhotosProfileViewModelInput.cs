namespace SOSPets.ViewModel.Session
{
    public class PhotosProfileViewModelInput
    {
        public string Image { get; set; }
        public void ReplaceBase64ForUrl(string url)
            => Image = url;
    }
}
