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

        /// <summary>
        /// Get countries from external API and apply manipulations on the data such like filter, sort and limit.
        /// </summary>
        /// <param name="nameCommon">A string to filter by countries' common name</param>
        /// <param name="populationAsMillions">Number to filter by (pass it as a million. Example: 1 = 1million)</param>
        /// <param name="sort">A string to sort by common name. (valid sorts "ascend" or "descend")</param>
        /// <param name="numberOfRecords">Number to limit the records of the data.</param>
        /// <returns>Manipulated data of CountryViewModel</returns>
        [HttpGet(Name = "GetCountries")]
        public async Task<IEnumerable<CountryViewModel>> Get(string? nameCommon, int? populationAsMillions, string? sort, int? numberOfRecords)
        {
            var countries = await GetAllCountries();

            var result = ManipulateTheData(nameCommon, populationAsMillions, sort, numberOfRecords, countries);

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

            return collection ?? Enumerable.Empty<CountryViewModel>();
        }
    }
}
