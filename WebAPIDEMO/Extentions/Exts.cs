using Newtonsoft.Json;
using System.Text.Json;

public static class Exts
{
    public static string ToJson(this object item)
    {
        return JsonConvert.SerializeObject(item, Formatting.Indented);
    }

    public static T? FromJson<T>(this JsonElement item)
    {
        return JsonConvert.DeserializeObject<T>(item.ToString());
    }
}

