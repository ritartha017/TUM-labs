using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spectre.Console;

namespace RestApiConsumer.Dtos;

public class CategoryShortDto
{
    [JsonProperty(PropertyName = "id")]
    public long Id { get; set; }
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "itemsCount")]
    public long ItemsCount { get; set; }
}

