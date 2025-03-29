using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string nombre)
    {
        string variableSaludo = "Hola " + nombre;
        ViewBag.atributoSaludo = variableSaludo;

        List<Auto> lista = new List<Auto>();

        Auto auto1 = new Auto();
        auto1.marca = "HONDA";
        auto1.modelo = "CIVIC";
        auto1.cantidadLlantas = 7;
        auto1.cantidadVentanas = 2;
        lista.Add(auto1);

        Auto auto2 = new Auto();
        auto2.marca = "FERRARI";
        auto2.modelo = "F5";
        auto2.cantidadLlantas = 3;
        auto2.cantidadVentanas = 1;
        lista.Add(auto2);

        ViewBag.listaAutos = lista;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
