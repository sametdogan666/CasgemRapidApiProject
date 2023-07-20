using System.Text.Json.Serialization;
using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers;

public class ImdbController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
            Headers =
            {
                { "X-RapidAPI-Key", "64530ed815msh7e6314fe21756e6p1bfc48jsn719a348b9c16" },
                { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<List<ImdbMovieListViewModel>>(body);

            return View(model);
        }

        return View();
    }
}