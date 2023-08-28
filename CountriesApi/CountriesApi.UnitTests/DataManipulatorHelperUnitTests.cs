namespace CountriesApi.UnitTests
{
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
