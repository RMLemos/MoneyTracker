using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Write your name.")]
    [Display(Name = "Username*")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Write your password.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password*")]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
}

