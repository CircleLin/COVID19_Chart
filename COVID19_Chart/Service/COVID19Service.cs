using COVID19_Chart.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace COVID19_Chart.Service
{
    public class COVID19Service : ICOVID19Service
    {
        private readonly HttpClient httpClient;

        private string baseurl { get; set; } = "https://api.covid19api.com";

        public COVID19Service(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// 取得國家清單
        /// </summary>
        /// <returns></returns>
        public async Task<List<CountryModel>> GetCountriesAsync()
        {
            List<CountryModel> countries = new List<CountryModel>();
            var response = await httpClient.GetAsync($"{baseurl}/countries");

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                countries = JsonConvert.DeserializeObject<List<CountryModel>>(contentString);
            }

            return countries;
        }

        /// <summary>
        /// 取得確診、死亡等等人數資料
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public async Task<List<CountrySummary>> GetCountrySummaryAsync(string countryCode)
        {
            List<CountrySummary> countrySummary = new List<CountrySummary>();

            var respones = await httpClient.GetAsync($"{baseurl}/country/{countryCode}");
            if (respones.IsSuccessStatusCode)
            {
                var contentString = await respones.Content.ReadAsStringAsync();
                countrySummary = JsonConvert.DeserializeObject<List<CountrySummary>>(contentString);
            }

            return countrySummary.TakeLast(60).ToList();
        }
    }
}