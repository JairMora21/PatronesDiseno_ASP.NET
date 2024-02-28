using DesingPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Tools.Generator;

namespace DesignPatternsAsp.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;
        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                //obtener la lista de cervezas
                var beer = _unitOfWork.Beers.GetAll();
                List<string> content = beer.Select(x => x.Name).ToList();

                //generar el archivo
                string path = "file" + DateTime.Now.Ticks + new Random().Next(100)+".txt";
                //Llamamos al director
                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                //Creamos el generador dependiendo de la opción
                if (optionFile == 1)
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                else 
                    generatorDirector.CreateSimplePipeGenerator(content, path);

                //Ejecutamos el generador y lo guardamos
                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();
                
                return Json("Archivo generado ");

            } catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
