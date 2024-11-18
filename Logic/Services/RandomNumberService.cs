using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class RandomNumberService : IRandomNumberService
    {
        private readonly HttpClient _httpClient;

        public RandomNumberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetRandomNumberAsync(int maxValue)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(
                    $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={maxValue - 1}" +
                    $"&count=1");

                var number = JsonConvert.DeserializeObject<int[]>(response);

                return number?[0] ?? new Random().Next(0, maxValue);
            }
            catch
            {
                return new Random().Next(0, maxValue);
            }
        }
    }
}
