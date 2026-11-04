using Michelangelo_s_Board_Game_Cafe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static Michelangelo_s_Board_Game_Cafe.Pages.KaydolModel;

namespace Michelangelo_s_Board_Game_Cafe.Pages
{
    public class GirisYapModel : PageModel
    {

        private readonly SignInManager<AppUser> _signInManager;

        public GirisYapModel(SignInManager<AppUser> signInManager) {
        _signInManager = signInManager;
        }


        [BindProperty]
        public LoginInputModel Input { get; set; } = new();

        public class LoginInputModel
        {
            [Required(ErrorMessage = "E-posta adresi zorunludur.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            public string Email { get; set; } = string.Empty;
            [Required(ErrorMessage = "Şifre zorunludur.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
            public bool RememberMe { get; set; }
        }


        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            var result = await _signInManager.PasswordSignInAsync(
                userName: Input.Email,
                password: Input.Password,
                isPersistent: Input.RememberMe,
                lockoutOnFailure: false
            );
            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya şifre girdiniz.");
            return Page();
        }
    }
}
