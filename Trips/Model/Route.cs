namespace Trips.Model;

public record Route(IEnumerable<Waypoint> Waypoints, float Distance, string? Description = null);

public record Waypoint(decimal Latitude, decimal Longitude);