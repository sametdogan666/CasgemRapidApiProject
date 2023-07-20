using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemRapidApi.Controllers;

public class BookingController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string adult = "2", string child = "1", string checkInDate = "2023-09-28", string checkOutDate = "2023-09-29", string roomNumber = "1", string cityId = "-553173")
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkInDate}&filter_by_currency=USD&dest_id={cityId}&locale=en-gb&checkout_date={checkOutDate}&units=metric&room_number={roomNumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
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
            var model = JsonConvert.DeserializeObject<HotelListViewModel>(body);

            return View(model.results.ToList());
        }
        return View();
    }

  
}