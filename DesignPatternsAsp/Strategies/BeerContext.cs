using DesignPatternsAsp.Models.ViewModels;
using DesingPatterns.Repository;

namespace DesignPatternsAsp.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _strategy;

        public IBeerStrategy BeerStrategy
        {
            set { _strategy = value; }
        }
        public BeerContext(IBeerStrategy beerStrategy)
        {
            _strategy = beerStrategy;
        }

        public void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork)
        {
            _strategy.Add(formViewModel, unitOfWork);
        }
    }
}
