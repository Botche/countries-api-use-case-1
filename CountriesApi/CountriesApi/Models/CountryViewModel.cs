namespace CountriesApi.Models
{
    using System.Text.Json.Serialization;

    public class CountryViewModel
    {
        public CountryViewModel()
        {
            Name = new CountryNameViewModel();
        }

        [JsonPropertyName("name")]
        public CountryNameViewModel Name { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }
    }
}
