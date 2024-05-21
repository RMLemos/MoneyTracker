using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "This field is required.")]
    [Display(Name = "Username*")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [EmailAddress]
    [Display(Name = "Email*")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password*")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password*")]
    [Compare("Password", ErrorMessage = "The password don´t match.")]
    public string? ConfirmPassword { get; set; }
}
