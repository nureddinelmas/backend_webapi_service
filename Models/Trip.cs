using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;


/// Here there are our model, all items model here we wrote. Id comes from database That's why we wrote Bson Object ID.
public class Trip
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = null!;


    [BsonElement("src_airport")]
    [JsonPropertyName("src_airport")]
    public string Src_airport { get; set; } = null!;


    [BsonElement("dst_airport")]
    [JsonPropertyName("dst_airport")]
    public string Dst_airport { get; set; } = null!;


    [BsonElement("codeshare")]
    [JsonPropertyName("codeshare")]
    public string Codeshare { get; set; } = null!;


    [BsonElement("stops")]
    [JsonPropertyName("stops")]
    public int Stops { get; set; } = 0;

    [BsonElement("details")]
    [JsonPropertyName("details")]
    public List<Details> Details { get; set; } = null!;


}

public class Details
{

    [BsonElement("airplane")]
    [JsonPropertyName("airplane")]
    public string Airplane { get; set; } = null!;

    [BsonElement("airline")]
    [JsonPropertyName("airline")]
    public string Airline { get; set; } = null!;
}




