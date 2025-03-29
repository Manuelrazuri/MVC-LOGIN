using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class AutoController : Controller
{
    private readonly ILogger<AutoController> _logger;

    public AutoController(ILogger<AutoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Auto> lista = new List<Auto>();

        ResultadoProceso resultado = new ResultadoProceso();
        AutoRepositorio repositorio = null;

        try {
            repositorio = new AutoRepositorio();

            resultado = repositorio.conectarBBDD();

            if (resultado.codigoResultado == 1) {
                lista = repositorio.listarAutos();
            }
        } catch (Exception ex) {
            resultado.codigoResultado = 0; //1: OK, 0: ERROR
            resultado.mensajeError = "Hubo un error. Detalles=" + ex.Message;
        } finally {
            if (repositorio != null) {
                if (repositorio.cn != null) {
                    if (repositorio.cn.State == System.Data.ConnectionState.Open) {
                        repositorio.cn.Close();
                    }

                    repositorio.cn = null;
                }
            }
        }

        ViewBag.listaAutos = lista;

        return View("ListaDeAutos");
    }

    public IActionResult AgregarAuto()
{
    return View();
}

[HttpPost]
public IActionResult GuardarAuto(Auto auto)
{
    ResultadoProceso resultado = new ResultadoProceso();
    AutoRepositorio repositorio = new AutoRepositorio();

    try
    {
        resultado = repositorio.conectarBBDD();

        if (resultado.codigoResultado == 1)
        {

            bool exito = repositorio.agregarAuto(auto);
            if (exito)
            {
                return RedirectToAction("Index");
            }
        }
    }
    catch (Exception ex)
    {
        ViewBag.ErrorMensaje = "Error al agregar auto: " + ex.Message;
        return View("AgregarAuto", auto);
    }
    finally
    {
        if (repositorio.cn != null && repositorio.cn.State == System.Data.ConnectionState.Open)
        {
            repositorio.cn.Close();
        }
    }

    return View("AgregarAuto", auto);
}
 
    public IActionResult EditarAuto(int id)
{
    Auto auto = null;
    ResultadoProceso resultado = new ResultadoProceso();
    AutoRepositorio repositorio = new AutoRepositorio();

    try
    {
        resultado = repositorio.conectarBBDD();

        if (resultado.codigoResultado == 1)
        {
            auto = repositorio.listarAutos().FirstOrDefault(a => a.codigo == id);
        }
    }
    catch (Exception ex)
    {
        ViewBag.ErrorMensaje = "Error al cargar el auto: " + ex.Message;
    }
    finally
    {
        if (repositorio.cn != null && repositorio.cn.State == System.Data.ConnectionState.Open)
        {
            repositorio.cn.Close();
        }
    }

    if (auto == null)
    {
        return NotFound();
    }

    return View(auto);
}

[HttpPost]
public IActionResult GuardarEditAuto(Auto auto)
{
    ResultadoProceso resultado = new ResultadoProceso();
    AutoRepositorio repositorio = new AutoRepositorio();

    try
    {
        resultado = repositorio.conectarBBDD();

        if (resultado.codigoResultado == 1)
        {
            bool exito = repositorio.editarAuto(auto);
            if (exito)
            {
                return RedirectToAction("Index");
            }
        }
    }
    catch (Exception ex)
    {
        ViewBag.ErrorMensaje = "Error al editar Auto: " + ex.Message;
        return View("EditarAuto", auto);
    }
    finally
    {
        if (repositorio.cn != null && repositorio.cn.State == System.Data.ConnectionState.Open)
        {
            repositorio.cn.Close();
        }
    }

    return View("EditarAuto", auto);
}

    public IActionResult EliminarAuto(int id)
{
    Auto auto = null;
    ResultadoProceso resultado = new ResultadoProceso();
    AutoRepositorio repositorio = new AutoRepositorio();

    try
    {
        resultado = repositorio.conectarBBDD();

        if (resultado.codigoResultado == 1)
        {
           auto = repositorio.listarAutos().FirstOrDefault(a => a.codigo == id);
        }
    }
    catch (Exception ex)
    {
        ViewBag.ErrorMensaje = "Error al eliminar el auto: " + ex.Message;
    }
    finally
    {
        if (repositorio.cn != null && repositorio.cn.State == System.Data.ConnectionState.Open)
        {
            repositorio.cn.Close();
        }
    }

    if (auto == null)
    {
        return NotFound();
    }

    return View(auto);
}

[HttpPost]
public IActionResult EliminarAuto(Auto auto)
{
    ResultadoProceso resultado = new ResultadoProceso();
    AutoRepositorio repositorio = new AutoRepositorio();

    try
    {
        resultado = repositorio.conectarBBDD();

        if (resultado.codigoResultado == 1)
        {
            bool exito = repositorio.eliminarAuto(auto);
            if (exito)
            {
                return RedirectToAction("Index");
            }
        }
    }
    catch (Exception ex)
    {
        ViewBag.ErrorMensaje = "Error al Eliminar Auto: " + ex.Message;
        return View("EliminarAuto", auto);
    }
    finally
    {
        if (repositorio.cn != null && repositorio.cn.State == System.Data.ConnectionState.Open)
        {
            repositorio.cn.Close();
        }
    }

    return View("EliminarAuto", auto);
}

public IActionResult BuscarAuto(string buscar)
{
    List<Auto> lista = new List<Auto>();
    ResultadoProceso resultado = new ResultadoProceso();
    AutoRepositorio repositorio = new AutoRepositorio();

    try
    {
        resultado = repositorio.conectarBBDD();

        if (resultado.codigoResultado == 1)
        {
            lista = repositorio.buscarAuto(buscar);
        }
    }
    catch (Exception ex)
    {
        ViewBag.ErrorMensaje = "Error al buscar autos: " + ex.Message;
    }
    finally
    {
        if (repositorio.cn != null && repositorio.cn.State == System.Data.ConnectionState.Open)
        {
            repositorio.cn.Close();
        }
    }

    ViewBag.listaAutos = lista;
    return View("ListaDeAutos"); 
}


}
