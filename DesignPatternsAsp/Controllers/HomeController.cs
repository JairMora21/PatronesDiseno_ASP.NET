using DesignPatternsAsp.Configuration;
using DesignPatternsAsp.Models;
using DesingPatterns.Models.Data;
using DesingPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Tools;

namespace DesignPatternsAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> _config;

        //declaramos el repositorio
        private readonly IRepository<Beer> _repository;

        //inyectamos el repositorio en el constructor
        public HomeController(IOptions<MyConfig> config, IRepository<Beer> repository)
        {
            _config = config;
            _repository = repository;
        }


        public IActionResult Index()
        {
            //obtenemos todas las cervezas
            IEnumerable<Beer> beers = _repository.GetAll();
            return View("Index", beers);
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.Pathlog).Save("Entro a privacidad");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
