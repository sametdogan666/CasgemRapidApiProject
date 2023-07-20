using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers;

public class ExchangeController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
            Headers =
            {
                { "X-RapidAPI-Key", "64530ed815msh7e6314fe21756e6p1bfc48jsn719a348b9c16" },
                { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ExchangeViewModel>(body);

            return View(model.exchange_rates.ToList());
        }
        return View();
    }

    public async Task<IActionResult> IndexExchange(string param= "TRY")
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency={param}&locale=en-gb"),
            Headers =
            {
                { "X-RapidAPI-Key", "64530ed815msh7e6314fe21756e6p1bfc48jsn719a348b9c16" },
                { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ExchangeViewModel>(body);

            return View(model.exchange_rates.ToList());
        }
        return View();
    }
}