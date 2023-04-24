using System;
using Newtonsoft.Json;

namespace RestApiConsumer.Dtos;

public class ProductShortDto
{
    [JsonProperty(PropertyName = "id")]
    public long Id { get; set; }
    [JsonProperty(PropertyName = "title")]
    public string? Title { get; set; }
    [JsonProperty(PropertyName = "price")]
    public Decimal Price { get; set; }
    [JsonProperty(PropertyName = "categoryId")]
    public long CategoryId { get; set; }
}

