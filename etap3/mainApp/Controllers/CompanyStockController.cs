using Microsoft.AspNetCore.Mvc;
using Platformy_Programowania_1.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace Platformy_Programowania_1.Controllers;

public class CompanyStockController : Controller
{
    private readonly AppDbContext _context;
    public CompanyStockController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateStock(string companyName)
    {
        string pythonScript = "wwwroot\\scripts\\StockAPI.py";
        string arguments = "2023-06-08"; // data startowa

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "python";
        startInfo.Arguments = $"{pythonScript} {arguments}";
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
        
        //using (var response = await client.SendAsync(request))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(body);
        //    var companyStock = JsonConvert.DeserializeObject<CompanyStock>(body);

        //    var newStock = companyStock?.Data?.Stock?.FirstOrDefault<Stock>() ?? throw new NullReferenceException();
        //    Console.WriteLine(newStock);
        //}

        //try
        //{
        //    var response = await client.SendAsync(request);
        //    response.EnsureSuccessStatusCode();
        //    var responseBody = await response.Content.ReadAsStringAsync();

        //    var companyStock = JsonConvert.DeserializeObject<CompanyStock>(responseBody);

        //    var newStock = companyStock?.Data?.Stock?.FirstOrDefault<Stock>() ?? throw new NullReferenceException();

        //    using (var db = new AppDbContext())
        //    {
        //        _context.Stocks.Add(newStock);
        //        _context.SaveChanges();
        //    }

        //    failedReguest = false;
        //}
        //catch(HttpRequestException ex)
        //{
        //    Console.WriteLine($"Request failed with error: {ex.Message}");  

        //}
        //catch(JsonSerializationException ex)
        //{
        //    Console.WriteLine($"JSON deserialization failed with error: {ex.Message}");
        //}
        //catch(NullReferenceException ex)
        //{            
        //    Console.WriteLine($"Stock data was not succesfully collected: {ex.Message}");  
        //}

        //if(failedReguest)
        //    TempData["FailedRequest"] = "Failed to receive data. Company name could be incorrect. Please check and try again";

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
