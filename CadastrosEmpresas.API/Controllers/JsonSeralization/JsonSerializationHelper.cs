using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonSerializationHelper
{
    public static string SerializeObject(object obj)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        return JsonSerializer.Serialize(obj, options);
    }
}
