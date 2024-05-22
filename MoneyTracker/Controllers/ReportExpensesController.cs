using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Context;
using MoneyTracker.Models;
using MoneyTracker.Services;

namespace MoneyTracker.Controllers;

[Authorize]
public class ReportExpensesController : Controller
{
    private readonly ReportExpensesService reportExpensesService;
    private readonly AppDbContext context;

    public ReportExpensesController(ReportExpensesService _reportExpensesService, AppDbContext _context)
    {
        reportExpensesService = _reportExpensesService;
        context = _context;
    }

    public IActionResult Index()
    {
        var categories = context.Categories.ToList();

        // Adiciona uma opção "Todas as categorias" no início da lista
        categories.Insert(0, new Category { CategoryId = 0, CategoryName = "All Categories" });
        ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
        return View();
    }

    public async Task<IActionResult> ReportExpenses(DateTime? minDate, DateTime? maxDate, int CategoryId)
    {
        Console.WriteLine($"A minha categoria é {CategoryId}");

        if (!minDate.HasValue)
        {
            minDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }

        var categories = context.Categories.ToList();

        ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        categories.Insert(0, new Category { CategoryId = 0, CategoryName = "All Categories" });
        ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");

        var result = await reportExpensesService.FindByDateAsync(minDate, maxDate, CategoryId);
        return View(result);
    }
}
