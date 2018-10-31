namespace TrackingFood.Core.Domain
{
    public class Appsettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string Dapper { get; set; }
    }
}