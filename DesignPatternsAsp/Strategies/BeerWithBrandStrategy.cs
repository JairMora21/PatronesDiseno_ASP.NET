using DesignPatternsAsp.Models.ViewModels;
using DesingPatterns.Models.Data;
using DesingPatterns.Repository;

namespace DesignPatternsAsp.Strategies
{
    public class BeerWithBrandStrategy : IBeerStrategy
    {
        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = formViewModel.Name;
            beer.Style = formViewModel.Style;

            var brand = new Brand();
            brand.Name = formViewModel.OtherBrand;
            brand.BrandId = new Random().Next(1, 1000);
            beer.BrandId = brand.BrandId;


            unitOfWork.Brands.Insert(brand);
            unitOfWork.Beers.Insert(beer);


            unitOfWork.Save();
        }
    }
}
