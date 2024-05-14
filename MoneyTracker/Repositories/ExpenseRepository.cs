using Microsoft.EntityFrameworkCore;
using MoneyTracker.Context;
using MoneyTracker.Models;
using MoneyTracker.Repositories.Interfaces;

namespace MoneyTracker.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Expense> Expenses => _context.Expenses.Include(c=> c.Category);

        public Expense GetExpenseById(int expenseId)
        {
            return _context.Expenses.FirstOrDefault(l => l.ExpenseId == expenseId);
        }
    }
}
