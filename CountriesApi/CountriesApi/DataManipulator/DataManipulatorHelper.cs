namespace CountriesApi.DataManipulator
{
    using CountriesApi.Constants;
    using CountriesApi.Models;

    public class DataManipulatorHelper
    {
        public DataManipulatorHelper(IEnumerable<CountryViewModel> countries)
        {
            this.Countries = countries;
        }

        public IEnumerable<CountryViewModel> Countries { get; set; }

        public void FilterByCommonName(string commonName)
        {
            this.Countries = this.Countries
                .Where(x => x.Name.Common.Contains(commonName, StringComparison.OrdinalIgnoreCase));
        }

        public void FilterByPopulation(int population)
        {
            var populationAsMillions = int.MaxValue;

            if (population < int.MaxValue / GlobalConstants.MILLION)
            {
                populationAsMillions = population * GlobalConstants.MILLION;
            }

            this.Countries = this.Countries
                .Where(x => x.Population < populationAsMillions);
        }

        public void SortByCommonName(string sort)
        {
            if (sort.Equals(GlobalConstants.ASCEND_SORT, StringComparison.OrdinalIgnoreCase))
            {
                this.Countries = this.Countries
                    .OrderBy(x => x.Name.Common);
            }
            else if (sort.Equals(GlobalConstants.DESCEND_SORT, StringComparison.OrdinalIgnoreCase))
            {
                this.Countries = this.Countries
                    .OrderByDescending(x => x.Name.Common);
            }
        }

        public void LimitTheRecords(int numberOfRecordst)
        {
            this.Countries = this.Countries
                .Take(numberOfRecordst);
        }
    }
}
