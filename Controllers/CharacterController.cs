using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentExerciseMVC_API.Models;

namespace StudentExerciseMVC_API.Controllers
{
  public class CharacterController : Controller
  {
    //public IActionResult Index()
    public async Task<IActionResult> Index()
    {
      //Fetch the JSON string from URl.
      List<CharacterViewModel> characters = new List<CharacterViewModel>();

      // Characters https://mocki.io/fake-json-api APIsta
      string url = "https://mocki.io/v1/d4867d8b-b5d5-4a48-a4ab-79131b5809b8";

      HttpClient httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Clear();
      httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

      HttpResponseMessage getData = await httpClient.GetAsync(url);

      if (getData.IsSuccessStatusCode)
      {
        string results = getData.Content.ReadAsStringAsync().Result;
        characters = JsonConvert.DeserializeObject<List<CharacterViewModel>>(results);
      }
      else
      {
        Console.WriteLine("Error calling web API.");
      }

      return View(characters);
    }
  }
}
