using Microsoft.AspNetCore.Mvc;
using Tools.Earn;
using Tools.Earn.ForeingEarnExtra;

namespace DesignPatternsAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        private EarnFactory _earnFactory;
        public ProductDetailController(EarnFactory earnFactory)
        {
            _earnFactory = earnFactory;
        }
        public IActionResult Index(decimal total)
        {
            //Aplicamos la inyección de dependencias
            var localEarnID = _earnFactory.GetEarn();
            var foreingEarnID = _earnFactory.GetEarn();


            //use products
            ViewBag.totalLocal = total + localEarnID.Earn(total);
            ViewBag.totalForeing = total + foreingEarnID.Earn(total);

            return View();
        }
    }
}
