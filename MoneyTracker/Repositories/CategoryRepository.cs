using MoneyTracker.Context;
using MoneyTracker.Models;
using MoneyTracker.Repositories.Interfaces;

namespace MoneyTracker.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> Categories => _context.Categories;
}
