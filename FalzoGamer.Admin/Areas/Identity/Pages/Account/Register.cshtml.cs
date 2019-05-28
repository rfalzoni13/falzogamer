using FalzoGamer.Admin.Models;
using FalzoGamer.Admin.Models.MailKit;
using FalzoGamer.Admin.Models.MailKit.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FalzoGamer.Admin.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailServico _emailServico;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment env,
            ILogger<RegisterModel> logger,
            IEmailServico emailServico)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailServico = emailServico;
            _env = env;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Nome")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} deve ter entre {2} a {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar senha")]
            [Compare("Password", ErrorMessage = "As senhas não conferem.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário criado com sucesso!");

                    _logger.LogInformation("Criando corpo de e-mail");

                    var pathToFile = _env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "templates"
                        + Path.DirectorySeparatorChar.ToString()
                        + "EmailConfirmation.html";

                    var builder = new BodyBuilder();

                    using (StreamReader sourceReader = System.IO.File.OpenText(pathToFile))
                    {
                        builder.HtmlBody = sourceReader.ReadToEnd();
                    }

                    var codigo = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = codigo },
                        protocol: Request.Scheme);

                    string messageBody = string.Format(builder.HtmlBody, callbackUrl);

                    _logger.LogInformation("Criando Email");
                    var mail = new MensagemEmail()
                    {
                        Assunto = "Confirmação de Email",
                        Conteudo = messageBody
                    };

                    mail.DeEndereco.Add(new EnderecoEmail() { Nome = "FalzoGamer", Endereco = "contato@falzogamer.com" });
                    mail.ParaEndereco.Add(new EnderecoEmail() { Nome = user.FirstName + " " + user.LastName, Endereco = Input.Email });

                    _logger.LogInformation("Enviando Email");
                    await _emailServico.SendAsync(mail);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
