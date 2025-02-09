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
        List<FishModel> fishList = new();

        if (System.IO.File.Exists(_filePath))
        {
            string jsonStr = System.IO.File.ReadAllText(_filePath);

            if (!string.IsNullOrWhiteSpace(jsonStr))
            {
                fishList = JsonSerializer.Deserialize<List<FishModel>>(jsonStr) ?? new List<FishModel>();
            }
        }

        fishList.Add(model);

        string newJsonStr = JsonSerializer.Serialize(fishList, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(_filePath, newJsonStr);

        TempData["SuccessMessage"] = "Fångsten har sparats!";

        return RedirectToAction("Index");
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
