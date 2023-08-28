namespace CountriesApi.Controllers
{
    using CountriesApi.Constants;
    using CountriesApi.DataManipulator;
    using CountriesApi.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;

    [ApiController]
    [Route("[controller]")]
    public class CountriesApiContoroller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CountriesApiContoroller(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetCountries")]
        public async Task<IEnumerable<CountryViewModel>> Get(string? nameCommon, int? population, string? sort, int? numberOfRecords)
        {
            var countries = await GetAllCountries();

            var result = ManipulateTheData(nameCommon, population, sort, numberOfRecords, countries);

            return result;
        }

        private static IEnumerable<CountryViewModel> ManipulateTheData(string? nameCommon, int? population, string? sort, int? numberOfRecords, IEnumerable<CountryViewModel> countries)
        {
            IDataManipulatorHelper dataManipulator = new DataManipulatorHelper(countries);

            dataManipulator.FilterByCommonName(nameCommon);
            dataManipulator.FilterByPopulation(population);
            dataManipulator.SortByCommonName(sort);
            dataManipulator.LimitTheRecords(numberOfRecords);

            return dataManipulator.Countries;
        }

        private async Task<IEnumerable<CountryViewModel>> GetAllCountries()
        {
            var collection = Enumerable.Empty<CountryViewModel>();

            var httpClient = httpClientFactory.CreateClient(GlobalConstants.COUNTRIES_CLIENT_NAME);
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
