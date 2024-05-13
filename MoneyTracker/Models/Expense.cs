namespace MoneyTracker.Models;

public class Expense
{
    public int ExpenseId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Payment { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}
