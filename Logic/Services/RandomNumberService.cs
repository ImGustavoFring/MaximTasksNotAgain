using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class RandomNumberService : IRandomNumberService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiString;

        public RandomNumberService(HttpClient httpClient, string apiString)
        {
            _httpClient = httpClient;
            _apiString = apiString;
        }

        public async Task<int> GetRandomNumberAsync(int maxValue)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_apiString}/random?min=0&max={maxValue - 1}&count=1");
                var numbers = JsonConvert.DeserializeObject<int[]>(response);

                return numbers?[0] ?? new Random().Next(0, maxValue);
            }
            catch
            {
                return new Random().Next(0, maxValue);
            }
        }
    }
}
