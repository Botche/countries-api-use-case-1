﻿namespace DataManipulatorApi.Controllers
{
    using DataManipulatorApi.Constants;
    using DataManipulatorApi.DataManipulator;
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

            var result = ManipulateTheData(nameCommon, population, sort, numberOfRecords, countries);

            return result;
        }

        private static IEnumerable<CountryViewModel> ManipulateTheData(string? nameCommon, int? population, string? sort, int? numberOfRecords, IEnumerable<CountryViewModel> countries)
        {
            var dataManipulator = new DataManipulatorHelper(countries);

            if (!string.IsNullOrEmpty(nameCommon))
            {
                dataManipulator.FilterByCommonName(nameCommon);
            }

            if (population.HasValue)
            {
                dataManipulator.FilterByPopulation(population.Value);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                dataManipulator.SortByCommonName(sort);
            }

            if (numberOfRecords.HasValue)
            {
                dataManipulator.LimitTheRecords(numberOfRecords.Value);
            }

            return dataManipulator.Collection;
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
