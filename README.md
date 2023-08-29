# countries-api-use-case-1

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Botche_countries-api-use-case-1&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Botche_countries-api-use-case-1)

## Project Description
Web API project created with .NET Core 6. 
The purpose of the API is to optimize data collected from an API to efficiently process and transform it into usable format for further representation. It is working with https://restcountries.com/v3.1/ API.
The available endpoint to work is GET /CountriesApiContoroller. It is accepting 4 parameters which are optional. 
- nameCommon: string parameter to filter by
- populationAsMillions: int parameter to filter by
- sort: string to sort by common name
- numberOfRecords: number to limit the records

## How to run locally
1. Clone the repository
2. Open the location directory
3. Open directory CountriesApi
4. Open solution item CountriesApi.sln
5. Run the API

## Examples (How to use)
Пreliminary steps:
1. Run the project
2. Click the endpoint
3. Click "Try it out" button

1. Simple run
    1. Click "Execute" button
    2. The result is all information from the external API without manipulations
2. Pass nameCommon
    1. Pass "st" to nameCommon parameter
    2. The result is only countries that contains "st" in their common name 
3. Pass nameCommon with upper letter. The result is the same
    1. Pass "St" to nameCommon parameter
    2. The result is only countries that contains "st" in their common name 
3. Pass populationAsMillions
    1. Pass 1 to populationAsMillions parameter
    2. The result is only countries that have population less than 1 million
4. Pass negative value to populationAsMillions
    1. Pass -1 to populationAsMillions parameter
    2. The result is empty collection
5. Pass 0 to populationAsMillions
    1. Pass 0 to populationAsMillions parameter
    2. The result is empty collection
6. Pass "ascend" to sort parameter
    1. Pass "ascend" to sort parameter
    2. The result is all countries sorted acsending by common name
7. Pass "descend" to sort parameter
    1. Pass "descend" to sort parameter
    2. The result is all countries sorted descending by common name
8. Pass something different to sort parameter
    1. Pass "test" to sort parameter
    2. The result is all countries without sorting
9. Pass numberOfRecords
    1. Pass 15 to numberOfRecords
    2. The result is first 15 countries
8. Pass all parameters
    1. Pass "united" to nameCommon parameter
    2. Pass 200 to populationAsMillions parameter
    3. Pass "descend" to sort parameter
    4. Pass 1 to numberOfRecords
    5. The result is all countries that have united in their common name and have less than 200 millions. Sorted by descending common name. Limited to only 1 result.
