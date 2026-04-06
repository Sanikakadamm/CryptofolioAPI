using AutoMapper;
using CryptoFolio.Application.DTO.Crypto;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace CryptoFolio.Infrastructure.Repository
{
    public class CryptoService : ICryptoService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;

        public CryptoService(ApplicationDbContext db, IMapper mapper, HttpClient httpClient, IConfiguration config)
        {
            this.db = db;
            this.mapper = mapper;
            this.httpClient = httpClient;
            this.config = config;
        }

        // 🔹 Get cryptos stored in DB
        public List<CryptoResponseDTO> GetAllCryptos()
        {
            var data = db.CryptoCurrencies.ToList();
            var res = mapper.Map<List<CryptoResponseDTO>>(data);
            return res;
        }

        // 🔹 Get crypto from DB by Id
        public CryptoResponseDTO GetCryptoById(int cryptoId)
        {
            var data = db.CryptoCurrencies.Find(cryptoId);
            var res = mapper.Map<CryptoResponseDTO>(data);
            return res;
        }

        // 🔹 Get coin details from CoinGecko
        public async Task<string> GetCoinFromAPI(string coinId)
        {
            var url = $"{config["CoinGecko:BaseUrl"]}/coins/{coinId}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-cg-demo-api-key", config["CoinGecko:ApiKey"]);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // 🔹 Get full coin list from CoinGecko
        public async Task<string> GetCoinListFromAPI()
        {
            var url = $"{config["CoinGecko:BaseUrl"]}/coins/list";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-cg-demo-api-key", config["CoinGecko:ApiKey"]);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}