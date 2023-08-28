﻿namespace DataManipulatorApi.DataManipulator
{
    using DataManipulatorApi.Constants;
    using DataManipulatorApi.Models;

    public class DataManipulatorHelper
    {
        public DataManipulatorHelper(IEnumerable<CountryViewModel> collection)
        {
            this.Collection = collection;
        }

        public IEnumerable<CountryViewModel> Collection { get; set; }

        public void FilterByCommonName(string commonName)
        {
            this.Collection = this.Collection
                .Where(x => x.Name.Common.Contains(commonName, StringComparison.OrdinalIgnoreCase));
        }

        public void FilterByPopulation(int population)
        {
            var populationAsMillions = int.MaxValue;

            if (population < int.MaxValue / GlobalConstants.MILLION)
            {
                populationAsMillions = population * GlobalConstants.MILLION;
            }

            this.Collection = this.Collection
                .Where(x => x.Population < populationAsMillions);
        }

        public void SortByCommonName(string sort)
        {
            if (sort.Equals(GlobalConstants.ASCEND_SORT, StringComparison.OrdinalIgnoreCase))
            {
                this.Collection = this.Collection
                    .OrderBy(x => x.Name.Common);
            }
            else if (sort.Equals(GlobalConstants.DESCEND_SORT, StringComparison.OrdinalIgnoreCase))
            {
                this.Collection = this.Collection
                    .OrderByDescending(x => x.Name.Common);
            }
        }

        public void LimitTheRecords(int numberOfRecordst)
        {
            this.Collection = this.Collection
                .Take(numberOfRecordst);
        }
    }
}
