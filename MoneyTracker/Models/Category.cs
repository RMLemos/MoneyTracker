using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The {0} must have at least {2} characters and the maximum length is {1} characters.")]
    [Display(Name = "Category Name")]
    public string? CategoryName { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "The {0} must have at least {2} characters and the maximum length is {1} characters.")]
    [Display(Name = "Description")]
    public string? Description { get; set;}
    public List<Expense>? Expenses { get; set; }
}
