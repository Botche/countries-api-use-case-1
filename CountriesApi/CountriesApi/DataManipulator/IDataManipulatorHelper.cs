namespace CountriesApi.DataManipulator
{
    using CountriesApi.Models;

    public interface IDataManipulatorHelper
    {
        public IEnumerable<CountryViewModel> Countries { get; set; }

        public void FilterByCommonName(string? commonName);

        public void FilterByPopulation(int? population);

        public void SortByCommonName(string? sort);

        public void LimitTheRecords(int? numberOfRecordst);
    }
}
