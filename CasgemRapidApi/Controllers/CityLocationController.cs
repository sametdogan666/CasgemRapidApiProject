using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers;

public class CityLocationController : Controller
{
    // GET
    public async Task<IActionResult> Index(string cityName = "Londra")
    {
        ViewBag.CityName = cityName;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=tr"),
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
            var model = JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);

            return View(model.Take(1).ToList());
        }
        return View();
    }
}