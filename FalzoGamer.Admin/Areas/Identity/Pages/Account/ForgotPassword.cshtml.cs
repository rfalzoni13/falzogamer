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
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace FalzoGamer.Admin.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ForgotPasswordModel> _logger;
        private readonly IEmailServico _emailServico;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, 
            IHostingEnvironment env,
            ILogger<ForgotPasswordModel> logger,
            IEmailServico emailServico)
        {
            _env = env;
            _userManager = userManager;
            _logger = logger;
            _emailServico = emailServico;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(Input.Email);
                    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                    {
                        _logger.LogWarning("Nenhum usuário encontrado!");
                        // Don't reveal that the user does not exist or is not confirmed
                        return RedirectToPage("./ForgotPasswordConfirmation");
                    }

                    _logger.LogInformation("Criando corpo de e-mail");

                    var pathToFile = _env.WebRootPath
                        + Path.DirectorySeparatorChar.ToString()
                        + "templates"
                        + Path.DirectorySeparatorChar.ToString()
                        + "PasswordRecoveryEmail.html";

                    var builder = new BodyBuilder();

                    using (StreamReader sourceReader = System.IO.File.OpenText(pathToFile))
                    {
                        builder.HtmlBody = sourceReader.ReadToEnd();
                    }
                    // For more information on how to enable account confirmation and password reset please 
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler: null,
                        values: new { code },
                        protocol: Request.Scheme);


                    string messageBody = string.Format(builder.HtmlBody, callbackUrl);

                    _logger.LogInformation("Criando Email");
                    var mail = new MensagemEmail()
                    {
                        Assunto = "Email de Recuperação de senha",
                        Conteudo = messageBody
                    };

                    mail.DeEndereco.Add(new EnderecoEmail() { Nome = "FalzoGamer", Endereco = "contato@falzogamer.com" });
                    mail.ParaEndereco.Add(new EnderecoEmail() { Nome = user.FirstName + " " + user.LastName, Endereco = Input.Email });

                    _logger.LogInformation("Enviando Email");
                    await _emailServico.SendAsync(mail);

                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                return Page();
            }
            catch(Exception ex)
            {
                _logger.LogError("Ocorreu o seguinte erro: " + ex.Message);
                return Page();
            }
        }
    }
}
