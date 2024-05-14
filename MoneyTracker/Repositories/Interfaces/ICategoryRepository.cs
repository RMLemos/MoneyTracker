using MoneyTracker.Models;

namespace MoneyTracker.Repositories.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> Categories { get; }
}
