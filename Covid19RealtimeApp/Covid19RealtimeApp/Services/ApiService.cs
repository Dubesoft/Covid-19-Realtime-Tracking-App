using Covid19RealtimeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Covid19RealtimeApp.Services
{
    public class ApiService
    {
        public static async Task<All> GetAll()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://corona.lmao.ninja/v2/all");
            return JsonConvert.DeserializeObject<All>(response);
        }

        public static async Task<List<Countries>> GetCountries()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://corona.lmao.ninja/v2/countries");
            return JsonConvert.DeserializeObject<List<Countries>>(response);
        }

        public static async Task<Country> GetCountry(string country)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://corona.lmao.ninja/v2/countries/" + country);
            return JsonConvert.DeserializeObject<Country>(response);
        }

        public static async Task<List<States>> GetStates()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://corona.lmao.ninja/v2/states");
            return JsonConvert.DeserializeObject<List<States>>(response);
        }

        public static async Task<List<JohnHopkinsCSSEData>> GetJohnHopkinsCSSEData()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://corona.lmao.ninja/v2/jhucsse");
            return JsonConvert.DeserializeObject<List<JohnHopkinsCSSEData>>(response);
        }

        public static async Task<HistoricalData> GetHistoricalData()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://corona.lmao.ninja/v2/historical");
            return JsonConvert.DeserializeObject<HistoricalData>(response);
        }
    }
}
