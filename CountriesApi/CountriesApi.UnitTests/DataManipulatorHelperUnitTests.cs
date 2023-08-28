namespace CountriesApi.UnitTests
{
    using CountriesApi.Constants;
    using CountriesApi.DataManipulator;
    using CountriesApi.UnitTests.Data;

    [TestClass]
    public class DataManipulatorHelperUnitTests
    {
        private readonly IDataManipulatorHelper dataManipulatorHelper;

        public DataManipulatorHelperUnitTests()
        {
            this.dataManipulatorHelper = new DataManipulatorHelper(CountriesData.GenerateCountriesData());
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
        [DataRow(null, CountriesData.CountOfCountries)]
        [DataRow("", CountriesData.CountOfCountries)]
        [DataRow(" ", CountriesData.CountOfCountries)]
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
        [DataRow(null, CountriesData.CountOfCountries)]
        public void FilterByPopulation_PassNull_ReturnsAllCountries(int? population, int expectedCount)
        {
            this.dataManipulatorHelper.FilterByPopulation(population);

            Assert.AreEqual(expectedCount, this.dataManipulatorHelper.Countries.Count());
        }

        [TestMethod]
        [DataRow(GlobalConstants.ASCEND_SORT, "Bulgaria")]
        [DataRow(GlobalConstants.DESCEND_SORT, "United States")]
        public void SortByCommonName_PassCorrectSort_ReturnsSorted(string sort, string expectedFirstCommonName)
        {
            this.dataManipulatorHelper.SortByCommonName(sort);

            var firstCountry = this.dataManipulatorHelper.Countries.First();
            Assert.AreEqual(expectedFirstCommonName, firstCountry.Name.Common);
        }

        [TestMethod]
        [DataRow("", "Bulgaria")]
        [DataRow(null, "Bulgaria")]
        [DataRow(" ", "Bulgaria")]
        [DataRow("sort", "Bulgaria")]
        public void SortByCommonName_PassIncorrectSort_ReturnsNonSorted(string? sort, string expectedFirstCommonName)
        {
            this.dataManipulatorHelper.SortByCommonName(sort);

            var firstCountry = this.dataManipulatorHelper.Countries.First();
            Assert.AreEqual(expectedFirstCommonName, firstCountry.Name.Common);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void LimitTheRecords_PassCorrectValue_ReturnLimitedData(int numberOfRecords)
        {
            this.dataManipulatorHelper.LimitTheRecords(numberOfRecords);

            Assert.AreEqual(numberOfRecords, this.dataManipulatorHelper.Countries.Count());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(-1)]
        public void LimitTheRecords_PassIncorrectValue_ReturnFullList(int? numberOfRecords)
        {
            this.dataManipulatorHelper.LimitTheRecords(numberOfRecords);

            Assert.AreEqual(CountriesData.CountOfCountries, this.dataManipulatorHelper.Countries.Count());
        }
    }
}
