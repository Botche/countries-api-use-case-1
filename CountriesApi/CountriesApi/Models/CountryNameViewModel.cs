namespace CountriesApi.Models
{
    using System.Text.Json.Serialization;

    public class CountryNameViewModel
    {
        public CountryNameViewModel()
        {
            Common = string.Empty;
            Official = string.Empty;
        }

        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]
        public string Official { get; set; }
    }
}
