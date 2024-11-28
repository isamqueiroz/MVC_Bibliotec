using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Bibliotec.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bibliotec.Models;

namespace Bibliotec_mvc.Contexts
{
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILogger<LivroController> _logger;

        public LivroController(ILogger<LivroController> logger)
        {
            _logger = logger;
        }

        Context context = new Context();

        public IActionResult Index()
        {
            ViewBag.Admin = HttpContext.Session.GetString("Admin")!;

            List<Livro> listaLivros = context.Livro.ToList();

            // Verificar se o livro tem reserva ou nao

            var LivrosReservados = context.LivroReserva.ToDictionary(Livro => Livro.LivroID, livror => livror.DtReserva);

            ViewBag.Livros = listaLivros;
            ViewBag.LivrosComReserva = LivrosReservados;




            return View();
        }


        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}