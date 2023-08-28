namespace DataManipulatorApi.Models
{
    using System.Text.Json.Serialization;

    public class CountryNameViewModel
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]
        public string Official { get; set; }
    }
}
