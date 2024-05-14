using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTracker.Models;

public class Expense
{
    [Key]
    public int ExpenseId { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "The {0} must have at least {2} characters and the maximum length is {1} characters.")]
    [Display(Name = "Expense")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "The {0} must have at least {2} characters and the maximum length is {1} characters.")]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [Display(Name = "Price")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 999.99, ErrorMessage = "The established price varies from 1 to 999,99")]
    public decimal Price { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Due Date")]
    public DateTime DueDate { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Payment Date")]
    public DateTime? Payment { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
