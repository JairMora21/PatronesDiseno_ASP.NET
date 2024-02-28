using DesignPatternsAsp.Models.ViewModels;
using DesignPatternsAsp.Strategies;
using DesingPatterns.Models.Data;
using DesingPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPatternsAsp.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from beer in _unitOfWork.Beers.GetAll()
                                               select new BeerViewModel
                                               {
                                                   Id = beer.BeerId,
                                                   Name = beer.Name,
                                                   Style = beer.Style
                                               };

            return View("Index", beers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            GetBrands();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormViewModel beerVM)
        {

            if (!ModelState.IsValid)
            {
                GetBrands();
                return View("Add", beerVM);
            }

            var context = beerVM.BrandId == null ? 
                  new BeerContext (new BeerStrategy()) : 
                  new BeerContext(new BeerWithBrandStrategy());
           
            context.Add(beerVM, _unitOfWork);

            return View("Create", beerVM);
        }

        #region HELPERS 
        private void GetBrands()
        {
            var brands = _unitOfWork.Brands.GetAll();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }
        #endregion
    }
}