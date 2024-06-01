namespace SOSPets.Models.Outputs;

public class AddressGeoOutput
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string UidProfileUser { get; set; }

    public AddressGeoOutput(){ }

    public AddressGeoOutput(string uidProfileUser, double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        UidProfileUser = uidProfileUser;
    }
}