namespace MoneyTracker.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set;}
    public List<Expense>? Expenses { get; set; }
}
