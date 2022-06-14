namespace Map;

public class DistanceCalculator : IDistanceCalculator
{
    public Dictionary<string, Tuple<double, double>> CitiesCoord { get; init; }

    public DistanceCalculator(string filePath = "Resources/wa_cities.csv")
    {
        CitiesCoord = new Dictionary<string, Tuple<double, double>>();
    }

    private string[] ReadFile(string path)
    {
        return File.ReadAllLines(path);
    }

    private double Distance(double lon1, double lat1, double lon2, double lat2)
    {
        // Earth's radius in miles
        double R = 3963;
        double phi1 = lat1 * Math.PI / 180; // φ, λ in radians
        double phi2 = lat2 * Math.PI / 180;
        double deltaPhi = (lat2 - lat1) * Math.PI / 180;
        double deltaLambda = (lon2 - lon1) * Math.PI / 180;

        double a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi / 2) +
                Math.Cos(phi1) * Math.Cos(phi2) *
                Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return R * c; // in miles
    }
}