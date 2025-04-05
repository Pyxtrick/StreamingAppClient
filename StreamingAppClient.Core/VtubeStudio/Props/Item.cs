namespace StreamingApp.API.VTubeStudio.Props;
public class Item
{
    public string fileName { get; set; }

    public string instanceID { get; set; }

    public float positionX { get; set; }

    public float positionY { get; set; }

    public float size { get; set; }

    public float rotation { get; set; }

    public bool flipped { get; set; }

    public int order { get; set; }

    public bool censored { get; set; }
}
