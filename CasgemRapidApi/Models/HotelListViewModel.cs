namespace CasgemRapidApi.Models;

public class HotelListViewModel
{
    public Result[] results { get; set; }

    public class Result
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string reviewScore { get; set; }
    }
}