using System.ComponentModel.DataAnnotations;

namespace ZM.Mvc.RavenDbUsers.ViewModels
{
    public class ForgotPasswordViewModel
    {
        #region Properties

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #endregion
    }

    public class ForgotViewModel
    {
        #region Properties

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #endregion
    }

    public class LoginViewModel
    {
        #region Properties

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        #endregion
    }

    public class RegisterViewModel
    {
        #region Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        #endregion
    }

    public class ResetPasswordViewModel
    {
        #region Properties

        public string Code { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        #endregion
    }
}