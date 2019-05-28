using AutoMapper;
using FalzoGamer.Api.Models;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Cross.Authentication;
using FalzoGamer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FalzoGamer.Api.Controllers
{
    /// <summary>
    /// Controller AccountController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAcessoAppServico _acessoAppServico;
        private readonly IUsuarioAppServico _usuarioAppServico;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ILogger<AccountController> _logger;

        /// <summary>
        /// Construtor BaseController que gera as interfaces _userManager e _roleManager
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="acessoAppServico"></param>
        /// <param name="usuarioAppServico"></param>
        /// <param name="signInManager"></param>
        /// <param name="tokenConfigurations"></param>
        /// <param name="signingConfigurations"></param>
        /// <param name="logger"></param>
        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IAcessoAppServico acessoAppServico,
            IUsuarioAppServico usuarioAppServico, SignInManager<ApplicationUser> signInManager, 
            TokenConfigurations tokenConfigurations,
            SigningConfigurations signingConfigurations,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _acessoAppServico = acessoAppServico;
            _usuarioAppServico = usuarioAppServico;
            _signInManager = signInManager;
            _tokenConfigurations = tokenConfigurations;
            _signingConfigurations = signingConfigurations;
            _logger = logger;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere um novo usuário na base Identity
        /// </remarks>
        /// <param name="usuarioModel">Objeto do usuário</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Registrar")]
        public async Task<ActionResult> Registrar(UsuarioModel usuarioModel)
        {
            _logger.LogDebug("Registrar - Iniciando método!");
            try
            {
                if (ModelState.IsValid && usuarioModel != null)
                {
                    var acesso = _acessoAppServico.BuscarPorId(usuarioModel.AcessoId);

                    if (acesso == null)
                    {
                        ModelState.AddModelError(string.Empty, "Nenhum acesso encontrado!");
                        _logger.LogWarning("Registrar - Nenhum acesso encontrado!");
                        return NotFound(ModelState);
                    }

                    var role = await _roleManager.FindByNameAsync(acesso.Nome);
                    if(role == null)
                    {
                        _logger.LogInformation("Registrar - Iniciando método RegistrarRole");
                        role = await RegistrarRole(acesso.Nome);
                    }

                    var user = new ApplicationUser
                    {
                        FirstName = usuarioModel.Nome.Split(' ').FirstOrDefault(),
                        LastName = usuarioModel.Nome.Split(' ').LastOrDefault(),
                        Email = usuarioModel.Email,
                        UserName = usuarioModel.Login,
                        EmailConfirmed = true
                    };

                    _logger.LogInformation("Registrar - Iniciando método RegistrarUsuario");
                    var result = await RegistrarUsuario(user);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError("Registrar - erro: " + error.Description);
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                    _logger.LogInformation("Registrar - Iniciando método AssociarRole");
                    result = await AssociarRole(user, role);
                    if(!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError("Registrar - erro: " + error.Description);
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    if(!string.IsNullOrEmpty(usuarioModel.Senha))
                    {
                        _logger.LogInformation("Registrar - Iniciando método InserirSenha");
                        result = await InserirSenha(user, usuarioModel.Senha);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                _logger.LogError("Registrar - erro: " + error.Description);
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        _logger.LogInformation("Registrar - criando objeto de usuário");

                        usuarioModel.Created = DateTime.Now;

                        usuarioModel.Novo = true;

                        var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);

                        _usuarioAppServico.Adicionar(usuario);

                        _logger.LogInformation("Registrar - Sucesso!");
                        return Ok("Usuário inserido com sucesso!");
                    }
                }

                _logger.LogWarning("Registrar - Ocorreram erros de validação de parâmetros: " + ModelState);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Registrar - erro: " + ex);

                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Gerar Token
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Gera novo Token
        /// </remarks>
        /// <param name="model">Objeto de login</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Token")]
        public async Task<ActionResult> Token(LoginModel model)
        {
            _logger.LogDebug("Token - Iniciando");
            try
            {
                if(model != null && ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if(user != null)
                    {
                        var resultado = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                        if(resultado.Succeeded)
                        {
                            _logger.LogInformation("Token - Criação de Claims");

                            var roles = await _userManager.GetRolesAsync(user);

                            var role = roles.FirstOrDefault();

                            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.UserName),
                                new[] {
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                                    new Claim(ClaimTypes.Role, role)
                                }
                            );

                            _logger.LogInformation("Token - Criação do Token");

                            DateTime Created = DateTime.Now;
                            DateTime Expired = Created + TimeSpan.FromDays(_tokenConfigurations.Expires);

                            var handler = new JwtSecurityTokenHandler();
                            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor {
                                Issuer = _tokenConfigurations.Issuer,
                                Audience = _tokenConfigurations.Audience,
                                SigningCredentials = _signingConfigurations.SigningCredentials,
                                Subject = identity,
                                NotBefore = Created,
                                Expires = Expired
                            });

                            var token = handler.WriteToken(securityToken);

                            var response = new TokenResponse
                            {
                                AcessToken = token,
                                Created = Created.ToString("dd/MM/yyyy HH:mm:ss"),
                                Expiration = Expired.ToString("dd/MM/yyyy HH:mm:ss")
                            };

                            _logger.LogInformation("Token - Sucesso!");
                            return Ok(response);
                        }
                        else
                        {
                            _logger.LogWarning("Token - Login ou senha incorretos");
                            return Forbid("Login ou senha incorretos");
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Token - Nenhum registro encontrado!");

                        return NotFound(new
                        {
                            Status = HttpStatusCode.NotFound,
                            Message = "Nenhum registro encontrado!"
                        });
                    }
                }

                _logger.LogError("Token - ocorreram erros de validação: " + ModelState);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError("Token - erro: " + ex);

                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Registrar usuário
        /// </summary>
        /// <remarks>
        /// Registra um novo usuário na base Identity
        /// </remarks>
        /// <param name="user">Objeto ApplicationUser</param>
        /// <returns></returns>
        [NonAction]
        private async Task<IdentityResult> RegistrarUsuario(ApplicationUser user)
        {
            _logger.LogDebug("RegistrarUsuario - Iniciando");

            if (user != null)
            {
                var result = await _userManager.CreateAsync(user);

                _logger.LogInformation("RegistrarUsuario - Sucesso!");
                return result;
            }
            else
            {
                _logger.LogError("RegistrarUsuario - Parâmetros nulos");
                throw new NullReferenceException("Parâmetros nulos!");
            }
        }

        /// <summary>
        /// Inserir senha
        /// </summary>
        /// <remarks>
        /// Insere uma nova senha para o usuário na base Identity
        /// </remarks>
        /// <param name="user">Objeto ApplicationUser</param>
        /// <param name="senha">String da senha</param>
        /// <returns></returns>
        [NonAction]
        private async Task<IdentityResult> InserirSenha(ApplicationUser user, string senha)
        {
            _logger.LogDebug("InserirSenha - Iniciando");

            if (user != null)
            {
                var result = await _userManager.AddPasswordAsync(user, senha);

                _logger.LogInformation("InserirSenha - Sucesso!");
                return result;
            }
            else
            {
                _logger.LogError("InserirSenha - Parâmetros nulos!");
                throw new NullReferenceException("Parâmetros nulos!");
            }
        }

        /// <summary>
        /// Associar role
        /// </summary>
        /// <remarks>
        /// Associa uma role ao usuário
        /// </remarks>
        /// <param name="user">Objeto ApplicationUser</param>
        /// <param name="role">Objeto IdentityRole</param>
        /// <returns></returns>
        [NonAction]
        private async Task<IdentityResult> AssociarRole(ApplicationUser user, IdentityRole role)
        {
            _logger.LogDebug("AssociarRole - Iniciando");

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name);

                _logger.LogInformation("AssociarRole - Sucesso!");
                return result;
            }
            else
            {
                _logger.LogError("AssociarRole - Parâmetros inválidos!");
                throw new NullReferenceException("Parâmetros nulos!");
            }
        }

        /// <summary>
        /// Registrar role
        /// </summary>
        /// <remarks>
        /// Registra uma nova role na base Identity
        /// </remarks>
        /// <param name="name">Nome da role</param>
        /// <returns></returns>
        [NonAction]
        private async Task<IdentityRole> RegistrarRole(string name)
        {
            _logger.LogDebug("RegistrarRole - Iniciando");

            if (!string.IsNullOrEmpty(name))
            {
                var role = await _roleManager.FindByNameAsync(name);
                if (role == null)
                {
                    role = new IdentityRole(name);
                    var result = await _roleManager.CreateAsync(role);
                    if (!result.Succeeded)
                    {
                        _logger.LogWarning("RegistrarRole - Erro no método CreateAsync, retornando null");
                        return null;
                    }
                }

                _logger.LogInformation("RegistrarRole - Sucesso!");
                return role;
            }
            else
            {
                _logger.LogError("RegistrarRole - Parâmetros inválidos");
                throw new NullReferenceException("Parâmetros nulos!");
            }
        }
    }
}