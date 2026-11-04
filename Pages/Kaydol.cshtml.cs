using Michelangelo_s_Board_Game_Cafe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Michelangelo_s_Board_Game_Cafe.Pages
{
    public class KaydolModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public KaydolModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; } = new();


        public class RegisterInputModel
        {
            [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
            [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir.")]
            public string FullName { get; set; } = string.Empty;
            [Required(ErrorMessage = "E-posta adresi zorunludur.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            public string Email { get; set; } = string.Empty;
            [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
            public string? Phone { get; set; }
            [Required(ErrorMessage = "Şifre zorunludur.")]
            [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
            [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
            [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; } = string.Empty;
        }


        public void OnGet()
        {
        }

       

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = new AppUser { UserName = Input.Email, Email = Input.Email, FullName = Input.FullName };
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Member");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Index");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }

    }
}
