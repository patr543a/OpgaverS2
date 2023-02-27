namespace SqlRocket.Database.Records
{
    public record struct Rocket(int RocketId, string RocketName, decimal Payload, decimal Width, decimal Height);

    public record struct LaunchSite(int LaunchSiteId, string SiteName, string Address, decimal Longitude, decimal Latitude, DateTime Founded);

    public record struct Launch(int LaunchId, string MissionName, int SiteId, int RocketId, DateTime Date);
}
