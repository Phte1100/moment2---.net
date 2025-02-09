using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2Mvc.Models;

namespace Moment2Mvc.Controllers;

public class HomeController : Controller
{
    private readonly string _filePath = "fiskar.json"; // Filen där fiskarna sparas

    public IActionResult Index()
    {
        // ViewBag och ViewData läggs till här
        ViewBag.WelcomeMessage = "Välkommen! Registrera din fångst här.";
        ViewData["InfoText"] = "Fyll i alla fält för att spara din fångst.";

        return View(new FishModel
{
    Species = string.Empty,
    Location = string.Empty,
    Description = string.Empty,
    Released = string.Empty,
    Date = DateTime.Today
});

    }

    [HttpPost]
    public IActionResult Index(FishModel model)
    {
        if (ModelState.IsValid)
        {
            List<FishModel> fishList = new();

            if (System.IO.File.Exists(_filePath))
            {
                string jsonStr = System.IO.File.ReadAllText(_filePath);

                if (!string.IsNullOrWhiteSpace(jsonStr))
                {
                    try
                    {
                        fishList = JsonSerializer.Deserialize<List<FishModel>>(jsonStr) ?? new List<FishModel>();
                    }
                    catch (JsonException)
                    {
                        // Om JSON är korrupt, starta en ny tom lista istället för att krascha
                        fishList = new List<FishModel>();
                    }
                }
            }

            fishList.Add(model);

            string newJsonStr = JsonSerializer.Serialize(fishList, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_filePath, newJsonStr);

            // Endast TempData bevaras vid RedirectToAction
            TempData["SuccessMessage"] = "Fångsten har sparats!";

            return RedirectToAction("Index"); // Viktigt för att TempData ska fungera
        }

        return View(model);
    }

    [HttpGet("/log")]
    public IActionResult Log()
    {
        List<FishModel> fishList = new();

        if (System.IO.File.Exists(_filePath))
        {
            string jsonStr = System.IO.File.ReadAllText(_filePath);

            if (!string.IsNullOrWhiteSpace(jsonStr))
            {
                try
                {
                    fishList = JsonSerializer.Deserialize<List<FishModel>>(jsonStr) ?? new List<FishModel>();
                }
                catch (JsonException)
                {
                    // Om JSON är felaktig, returnera en tom lista istället för att krascha
                    fishList = new List<FishModel>();
                }
            }
        }

        return View(fishList);
    }

    [HttpGet("/omsidan")]
    public IActionResult About()
    {
        return View();
    }
}
