using MoneyTracker.Models;

namespace MoneyTracker.Repositories.Interfaces;

public interface IExpenseRepository
{
    IEnumerable<Expense> Expenses { get; }
    Expense GetExpenseById (int expenseId);
}
