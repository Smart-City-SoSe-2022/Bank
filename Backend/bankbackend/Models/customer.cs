using System.Text.Json.Serialization;

namespace bankbackend.Models;

public class customer
{
    [JsonPropertyName("id")]
    public int id { get; set; }
    public string name { get; set; }
    public string surename { get; set; }
    public string adress { get; set; }
    public string email { get; set; }
    public string username { get; set; }

}