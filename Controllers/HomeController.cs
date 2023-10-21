using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using sessionworkshop.Models;

namespace sessionworkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost]
    [Route("loginProcess")]
    public IActionResult loginProcess(string Name){
        
        HttpContext.Session.SetString("UserName", Name);
        HttpContext.Session.SetInt32("Number", 21);
    

        return View("Game");
    }

    public IActionResult Cleaner(string Name){
        
        HttpContext.Session.Clear();
    

        return RedirectToAction("Index");
    }

     public IActionResult Plus(){
        
        int  num = (Int32) HttpContext.Session.GetInt32("Number"); 
        int suma = num + 1 ;
        HttpContext.Session.SetInt32("Number", suma);
        return View("Game");
    }

     public IActionResult Minus(){
        
        int  num = (Int32) HttpContext.Session.GetInt32("Number"); 
        int resta = num - 1 ;
        HttpContext.Session.SetInt32("Number", resta);
        return View("Game");
    }

     public IActionResult Multi(){
        
        int  num = (Int32) HttpContext.Session.GetInt32("Number"); 
        int multi = num * 2 ;
        HttpContext.Session.SetInt32("Number", multi);
        return View("Game");
    }
    
     public IActionResult Randx(){
        Random rnd = new Random();
        int numran = rnd.Next(0,11);
        int  num = (Int32) HttpContext.Session.GetInt32("Number"); 
        int multi = num * numran ;
        HttpContext.Session.SetInt32("Number", multi);
        return View("Game");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
