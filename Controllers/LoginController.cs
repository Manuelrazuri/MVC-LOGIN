using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<AutoController> _logger;

    public LoginController(ILogger<AutoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

     public IActionResult Registrar()
    {
        return View();
    }
}

