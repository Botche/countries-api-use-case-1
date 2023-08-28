namespace DataManipulatorApi.Models
{
    using System.Text.Json.Serialization;

    public class CountryNameViewModel
    {
        public CountryNameViewModel()
        {
            this.Common = string.Empty;
            this.Official = string.Empty;
        }

        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]
        public string Official { get; set; }
    }
}
