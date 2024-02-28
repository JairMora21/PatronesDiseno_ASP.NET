using DesignPatternsAsp.Models.ViewModels;
using DesingPatterns.Models.Data;
using DesingPatterns.Repository;

namespace DesignPatternsAsp.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork)
        {

            var brand = new Beer();
            brand.Name = formViewModel.Name;
            brand.Style = formViewModel.Style;
            brand.BrandId = new Random().Next(1, 1000);

            unitOfWork.Beers.Insert(brand);
            unitOfWork.Save();

        }
    }
}
