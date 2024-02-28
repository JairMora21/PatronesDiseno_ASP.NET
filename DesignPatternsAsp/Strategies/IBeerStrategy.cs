using DesignPatternsAsp.Models.ViewModels;
using DesingPatterns.Repository;

namespace DesignPatternsAsp.Strategies
{
    public interface IBeerStrategy
    {
        void Add(FormViewModel formViewModel, IUnitOfWork unitOfWork);
    }
}
