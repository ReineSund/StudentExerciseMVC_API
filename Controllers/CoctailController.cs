using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudentExerciseMVC_API.Models;
using System.Net.Http.Headers;

namespace StudentExerciseMVC_API.Controllers
{
  public class CoctailController : Controller
  {
    //public IActionResult Index()
    public async Task<IActionResult> Index()
    {
      //Fetch the JSON string from URL.
      List<CoctailViewModel> drinks = new List<CoctailViewModel>();

      // Drinksut thecoctaildb.com APIsta
      string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail";

      HttpClient httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Clear();
      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appliction/json"));

      HttpResponseMessage getData = await httpClient.GetAsync(url);

      if (getData.IsSuccessStatusCode)
      {
        string results = getData.Content.ReadAsStringAsync().Result;
        JObject json = JObject.Parse(results);
        JArray drinkArray = (JArray)json["drinks"];
        drinks = drinkArray.ToObject<List<CoctailViewModel>>();
      }
      else
      {
        Console.WriteLine("Error calling web API.");
      }
        return View(drinks);
    }
  }
}
