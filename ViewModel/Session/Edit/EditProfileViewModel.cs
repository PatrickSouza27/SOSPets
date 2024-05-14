namespace SOSPets.ViewModel.Session.Edit
{
    public class EditProfileViewModel
    {
        public string Description { get; set; }
        public string Image {  get; set; }


        public void ReplaceBase64ForUrl(string url)
            => Image = url;
    }
}
