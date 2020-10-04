using COVID19_Chart.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19_Chart.Service
{
    public interface ICOVID19Service
    {
        Task<List<CountryModel>> GetCountriesAsync();

        Task<List<CountrySummary>> GetCountrySummaryAsync(string countryCode);
    }
}