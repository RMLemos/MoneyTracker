using Microsoft.EntityFrameworkCore;
using MoneyTracker.Context;
using MoneyTracker.Models;

namespace MoneyTracker.Services;

public class ReportExpensesService
{
    private readonly AppDbContext context;

    public ReportExpensesService(AppDbContext _context)
    {
        context = _context;
    }

    public async Task<List<Expense>> FindByDateAsync(DateTime? minDate, DateTime? maxDate, int CategoryId)
    {
        var result = from obj in context.Expenses select obj;

        if (CategoryId == 0)
        {
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Payment >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Payment <= maxDate.Value);
            }
            return await result
                         .OrderByDescending(x => x.Payment)
                         .ToListAsync();
        }
        else
        {
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Payment >= minDate.Value && x.CategoryId == CategoryId);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Payment <= maxDate.Value && x.CategoryId == CategoryId);
            }
            return await result
                         .OrderByDescending(x => x.Payment)
                         .ToListAsync();
        }
    }
}
