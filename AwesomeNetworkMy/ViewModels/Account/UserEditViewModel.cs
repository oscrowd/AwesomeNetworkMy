
using System.ComponentModel.DataAnnotations;

namespace AwesomeNetworkMy.ViewModels.Account;

public class UserEditViewModel
{

    [Required]
    [Display(Name = "Id", Prompt = "Id")]
    public string? UserId { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email", Prompt = "Введите email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль", Prompt = "Введите пароль")]
    public string Password { get; set; }

    [Display(Name = "Запомнить?")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}