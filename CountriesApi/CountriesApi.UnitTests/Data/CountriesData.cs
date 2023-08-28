namespace CountriesApi.UnitTests.Data
{
    using CountriesApi.Models;

    public static class CountriesData
    {
        public const int CountOfCountries = 7;

        public static IEnumerable<CountryViewModel> GenerateCountriesData()
        {
            return new List<CountryViewModel>()
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
        }
    }
}
