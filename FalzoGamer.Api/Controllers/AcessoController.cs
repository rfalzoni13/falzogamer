using AutoMapper;
using FalzoGamer.Api.Models;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FalzoGamer.Api.Controllers
{
    /// <summary>
    /// Controller AcessoController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly IAcessoAppServico _acessoAppServico;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Construtor AcessoController que gera as interfaces _acessoAppServico e _roleManager
        /// </summary>
        /// <param name="acessoAppServico"></param>
        /// <param name="roleManager"></param>
        public AcessoController(IAcessoAppServico acessoAppServico, RoleManager<IdentityRole> roleManager)
        {
            _acessoAppServico = acessoAppServico;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Listar todos os acessos
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém a lista completa de acessos da Api
        /// </remarks>
        /// <returns></returns>
        //GET api/acesso/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {
                var acessos = _acessoAppServico.BuscarTodos();

                if (acessos != null && acessos.Count() > 0)
                {
                    return Ok(acessos);
                }
                else
                {
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
                }
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Listar acesso pelo Id
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém o acesso através do seu Id
        /// </remarks>
        /// <param name="id">Id do acesso</param>
        /// <returns></returns>
        //GET api/acesso/BuscarPorId?id={id}
        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId([FromQuery] int id)
        {
            try
            {
                var acesso = _acessoAppServico.BuscarPorId(id);

                if (acesso != null)
                {
                    return Ok(acesso);
                }
                else
                {
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
                }
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Inserir acesso
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere um novo acesso na base
        /// </remarks>
        /// <param name="acessoModel">Objeto do acesso</param>
        /// <returns></returns>
        //POST api/acesso/Inserir
        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] AcessoModel acessoModel)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(acessoModel.Nome);
                if(role == null)
                {
                    role = new IdentityRole(acessoModel.Nome);
                    await _roleManager.CreateAsync(role);
                }

                acessoModel.Created = DateTime.Now;

                acessoModel.Novo = true;

                var acesso = Mapper.Map<AcessoModel, Acesso>(acessoModel);

                _acessoAppServico.Adicionar(acesso);

                return Ok("Acesso incluído com sucesso!");
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Atualizar acesso
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Atualiza o acesso na base
        /// </remarks>
        /// <param name="acessoModel">Objeto do acesso</param>
        /// <returns></returns>
        //POST api/acesso/Atualizar
        [HttpPost]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AcessoModel acessoModel)
        {
            try
            {
                var obj = _acessoAppServico.BuscarPorId(acessoModel.Id);
                if (obj != null)
                {
                    var role = await _roleManager.FindByNameAsync(obj.Nome);
                    if (role != null)
                    {
                        role.Name = acessoModel.Nome;
                        await _roleManager.UpdateAsync(role);
                    }
                    else
                    {
                        role = new IdentityRole(acessoModel.Nome);
                        await _roleManager.CreateAsync(role);
                    }
                }

                acessoModel.Modified = DateTime.Now;

                acessoModel.Novo = false;

                var acesso = Mapper.Map<AcessoModel, Acesso>(acessoModel);

                _acessoAppServico.Atualizar(acesso);

                return Ok("Acesso atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Excluir acesso
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Exclui o acesso da base
        /// </remarks>
        /// <param name="id">Id do acesso</param>
        /// <returns></returns>
        //DELETE api/acesso/Excluir
        [HttpDelete]
        [Route("Excluir")]
        public async Task<IActionResult> Excluir([FromQuery] int id)
        {
            try
            {
                var acesso = _acessoAppServico.BuscarPorId(id);

                var role = await _roleManager.FindByNameAsync(acesso.Nome);
                if (role != null)
                {
                    await _roleManager.DeleteAsync(role);
                }
                else
                {
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
                }

                if (acesso != null)
                {
                    _acessoAppServico.Apagar(acesso);

                    return Ok("Acesso apagado com sucesso!");
                }
                else
                {
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
                }

            }
            catch (Exception ex)
            {
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }
    }
}