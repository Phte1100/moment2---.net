using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2Mvc.Models;

namespace Moment2Mvc.Controllers;

public class HomeController : Controller
{
    private readonly string _filePath = "fiskar.json"; // Filen där fiskarna sparas

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(FishModel model)
    {
        if (ModelState.IsValid)
        {
            List<FishModel> fishList = new(); // Skapa en ny lista

            // Kontrollera om filen existerar
            if (System.IO.File.Exists(_filePath))
            {
                string jsonStr = System.IO.File.ReadAllText(_filePath);

                // Deserialisera JSON-filen och skapa en tom lista om den är null
                fishList = JsonSerializer.Deserialize<List<FishModel>>(jsonStr) ?? new List<FishModel>();
            }

            // Lägg till den nya fisken i listan
            fishList.Add(model);

            // Serialisera listan tillbaka till JSON-filen
            string newJsonStr = JsonSerializer.Serialize(fishList, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_filePath, newJsonStr);

            ModelState.Clear(); // Rensa formuläret
        }
        return View();
    }

    [HttpGet("/log")]
    public IActionResult Log()
    {
        List<FishModel> fishList = new();

        if (System.IO.File.Exists(_filePath))
        {
            string jsonStr = System.IO.File.ReadAllText(_filePath);
            fishList = JsonSerializer.Deserialize<List<FishModel>>(jsonStr) ?? new List<FishModel>();
        }

        return View(fishList);
    }

    [HttpGet("/omsidan")]
    public IActionResult About()
    {
        return View();
    }
}
