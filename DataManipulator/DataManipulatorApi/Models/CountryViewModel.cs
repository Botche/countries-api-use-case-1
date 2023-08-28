namespace DataManipulatorApi.Models
{
    using System.Text.Json.Serialization;

    public class CountryViewModel
    {
        public CountryViewModel()
        {
            this.Name = new CountryNameViewModel();
        }

        [JsonPropertyName("name")]
        public CountryNameViewModel Name { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }
    }
}
