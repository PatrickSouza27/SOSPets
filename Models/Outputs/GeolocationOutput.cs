namespace SOSPets.Models.Outputs
{
    public class GeolocationOutput
    {
        public double Lat { get; set; }
        public double Long { get; set; }

        public GeolocationOutput(double lat, double longi)
        {
            Lat = lat;
            Long = longi;
        }


    }
}
