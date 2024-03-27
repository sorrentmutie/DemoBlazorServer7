namespace DemoBlazor.Models;

public class MapSettings
{
    public string Id { get; set; } = "map";
    public double Latitudine { get; set; }
    public double Longitudine { get; set; }
    public int Zoom { get; set; }
    public int Height { get; set; }
}
