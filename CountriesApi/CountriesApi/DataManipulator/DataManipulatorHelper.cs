namespace CountriesApi.DataManipulator
{
    using CountriesApi.Constants;
    using CountriesApi.Models;

    public class DataManipulatorHelper : IDataManipulatorHelper
    {
        public DataManipulatorHelper(IEnumerable<CountryViewModel> countries)
        {
            Countries = countries;
        }

        public IEnumerable<CountryViewModel> Countries { get; set; }

        public void FilterByCommonName(string? commonName)
        {
            if (string.IsNullOrWhiteSpace(commonName))
            {
                return;
            }

            Countries = Countries
                .Where(x => x.Name.Common.Contains(commonName, StringComparison.OrdinalIgnoreCase));
        }

        public void FilterByPopulation(int? population)
        {
            if (!population.HasValue)
            {
                return;
            }

            var populationAsMillions = int.MaxValue;

            if (population < int.MaxValue / GlobalConstants.MILLION)
            {
                populationAsMillions = population.Value * GlobalConstants.MILLION;
            }

            Countries = Countries
                .Where(x => x.Population < populationAsMillions);
        }

        public void SortByCommonName(string? sort)
        {
            if (string.IsNullOrWhiteSpace(sort))
            {
                return;
            }

            if (sort.Equals(GlobalConstants.ASCEND_SORT, StringComparison.OrdinalIgnoreCase))
            {
                Countries = Countries
                    .OrderBy(x => x.Name.Common);
            }
            else if (sort.Equals(GlobalConstants.DESCEND_SORT, StringComparison.OrdinalIgnoreCase))
            {
                Countries = Countries
                    .OrderByDescending(x => x.Name.Common);
            }
        }

        public void LimitTheRecords(int? numberOfRecords)
        {
            if (!numberOfRecords.HasValue)
            {
                return;
            }

            Countries = Countries
                .Take(numberOfRecords.Value);
        }
    }
}
