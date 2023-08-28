using CountriesApi.DataManipulator;
using CountriesApi.Models;

namespace CountriesApi.UnitTests
{
    [TestClass]
    public class DataManipulatorHelperUnitTests
    {
        private readonly IDataManipulatorHelper dataManipulatorHelper;

        public DataManipulatorHelperUnitTests()
        {
            var countries = new List<CountryViewModel>()
            {
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "Bulgaria",
                        Official = "Republic of Bulgaria",
                    },
                    Population = 6927288,
                },
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "Christmas Island",
                        Official = "Territory of Christmas Island",
                    },
                    Population = 2072,
                },
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "Saint Helena, Ascension and Tristan da Cunh",
                        Official = "Saint Helena, Ascension and Tristan da Cunha",
                    },
                    Population = 53192,
                },
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "Estonia",
                        Official = "Republic of Estonia",
                    },
                    Population = 1331057,
                },
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "United Kingdom",
                        Official = "United Kingdom of Great Britain and Northern Ireland",
                    },
                    Population = 67215293,
                },
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "United Arab Emirates",
                        Official = "United Arab Emirates",
                    },
                    Population = 9890400,
                },
                new CountryViewModel()
                {
                    Name = new CountryNameViewModel
                    {
                        Common = "United States",
                        Official = "United States of America",
                    },
                    Population = 329484123,
                },
            };

            this.dataManipulatorHelper = new DataManipulatorHelper(countries);
        }

        [TestMethod]
        [DataRow("bul", 1)]
        [DataRow("united", 3)]
        [DataRow("st", 4)]
        public void FilterByCommonName_PassString_ReturnsCountriesThatContainsTheString(string commonName, int expectedCount)
        {
            this.dataManipulatorHelper.FilterByCommonName(commonName);

            Assert.AreEqual(expectedCount, this.dataManipulatorHelper.Countries.Count());
        }

        [TestMethod]
        [DataRow(null, 7)]
        [DataRow("", 7)]
        [DataRow(" ", 7)]
        public void FilterByCommonName_PassNullOrEmpty_ReturnsAllCountries(string? commonName, int expectedCount)
        {
            this.dataManipulatorHelper.FilterByCommonName(commonName);

            Assert.AreEqual(expectedCount, this.dataManipulatorHelper.Countries.Count());
        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(10, 5)]
        [DataRow(100, 6)]
        public void FilterByPopulation_PassCorrectValue_ReturnsCountriesWithLessPopulation(int population, int expectedCount)
        {
            this.dataManipulatorHelper.FilterByPopulation(population);

            Assert.AreEqual(expectedCount, this.dataManipulatorHelper.Countries.Count());
        }

        [TestMethod]
        [DataRow(null, 7)]
        public void FilterByPopulation_PassNull_ReturnsAllCountries(int? population, int expectedCount)
        {
            this.dataManipulatorHelper.FilterByPopulation(population);

            Assert.AreEqual(expectedCount, this.dataManipulatorHelper.Countries.Count());
        }
    }
}
