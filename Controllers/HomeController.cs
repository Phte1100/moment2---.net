using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2Mvc.Models;

namespace Moment2Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] 
    public IActionResult Index(FishModel Model) {
        return View();
    }

    [HttpGet("/log")]
    public IActionResult Log(FishModel model)
    {
        //Validera input
        if(ModelState.IsValid) 
        {
            // Läsa in json-fil
            string jsonStr = System.IO.File.ReadAllText("fiskar.json");
            // deserialisera json-fil
            var fishList = JsonSerializer.Deserialize<List<FishModel>>(jsonStr);

            // Lägg till ny fisk
            if (fishList != null) 
            {
                fishList.Add(model);
                // Serialisera listan
                jsonStr = JsonSerializer.Serialize(fishList);
                System.IO.File.WriteAllText("fiskar.json", jsonStr);
            }
        }
        return View();
    }

    [HttpGet("/omsidan")]
    public IActionResult About()
    {
        return View();
    }
    

}