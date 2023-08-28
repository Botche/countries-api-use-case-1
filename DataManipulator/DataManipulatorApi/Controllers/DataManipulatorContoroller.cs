namespace DataManipulatorApi.Controllers
{
    using DataManipulatorApi.Constants;
    using DataManipulatorApi.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;

    [ApiController]
    [Route("[controller]")]
    public class DataManipulatorContoroller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DataManipulatorContoroller(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetCountries")]
        public async Task<IEnumerable<CountryViewModel>> Get(string? nameCommon, int? population, string? sort, int? numberOfRecords)
        {
            var countries = await GetAllCountries();

            return countries;
        }

        private async Task<IEnumerable<CountryViewModel>> GetAllCountries()
        {
            var collection = Enumerable.Empty<CountryViewModel>();

            var httpClient = this.httpClientFactory.CreateClient(GlobalConstants.COUNTRIES_CLIENT_NAME);
            var httpResponseMessage = await httpClient.GetAsync("all");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                collection = await JsonSerializer
                    .DeserializeAsync<IEnumerable<CountryViewModel>>(contentStream);
            }

            return collection;
        }
    }
}
