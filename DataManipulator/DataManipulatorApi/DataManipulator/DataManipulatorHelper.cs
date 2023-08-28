namespace DataManipulatorApi.DataManipulator
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
    }
}
