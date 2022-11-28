namespace AutomaticBroccoli.CLI;
using System.Text.Json;

public class OpenLoop
{
    public string Note { get; set; }
    public  DateTimeOffset CreateData { get; set; }
}

public class OpenLoopsRepository
{
    private const string DirectoryName = "./openLoops/";
    public bool Add(OpenLoop newOpenloop)
    {
        Directory.CreateDirectory(DirectoryName);
        var json = JsonSerializer.Serialize(newOpenloop, new JsonSerializerOptions{WriteIndented = true});
        var fileName = $"{Guid.NewGuid()}.json";
        var filePath = Path.Combine(DirectoryName,fileName);
        File.WriteAllText(filePath,json);
        return true;
    }
    public OpenLoop[] Get()
    {
        var files = Directory.GetFiles(DirectoryName);
        var openLoops = new List<OpenLoop>();
        foreach (var file in files)
        {
            var json = File.ReadAllText(file);
            var openLoop = JsonSerializer.Deserialize<OpenLoop>(json);
            if (openLoop == null)
            {
                throw new Exception("OpenLoop cannot be deserialized");
            }
             openLoops.Add(openLoop);
        }
       return openLoops.ToArray();
    }
}