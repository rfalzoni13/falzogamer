using AutoMapper;
using FalzoGamer.Api.Models;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;

namespace FalzoGamer.Api.Controllers
{
    /// <summary>
    /// Controller UsuarioController
    /// </summary>
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppServico _usuarioAppServico;
        private readonly ILogger<UsuarioController> _logger;
        
        /// <summary>
        /// Construtor UsuarioController que gera as interfaces _usuarioAppServico,
        /// _acessoAppServico e os Identity Managers
        /// </summary>
        /// <param name="usuarioAppServico"></param>
        /// <param name="logger"></param>
        public UsuarioController(IUsuarioAppServico usuarioAppServico, ILogger<UsuarioController> logger)
        {
            _usuarioAppServico = usuarioAppServico;
            _logger = logger;
        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém a lista completa de usuários da Api
        /// </remarks>
        /// <returns></returns>
        //GET api/usuario/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            _logger.LogDebug("Listar - Iniciando");
            try
            {
                var usuarios = _usuarioAppServico.BuscarTodos();

                if (usuarios != null && usuarios.Count() > 0)
                {
                    _logger.LogInformation("Listar - Sucesso!");
                    return Ok(usuarios);
                }
                else
                {
                    _logger.LogWarning("Listar - Nenhum registro encontrado!");
                    return NotFound(new { Status = HttpStatusCode.NotFound,
                    Message = "Nenhum registro encontrado!" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Listar - erro: " + ex);
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Listar usuário pelo Id
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém o usuário através do seu Id
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        //GET api/usuario/BuscarPorId?id={id}
        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId([FromQuery] int id)
        {
            _logger.LogDebug("BuscarPorId - Iniciando");
            try
            {
                var usuario = _usuarioAppServico.BuscarPorId(id);

                if (usuario != null)
                {
                    _logger.LogInformation("BuscarPorId - Sucesso!");
                    return Ok(usuario);
                }
                else
                {
                    _logger.LogWarning("BuscarPorId - Nenhum registro encontrado!");
                    return NotFound(new { Status = HttpStatusCode.NotFound,
                    Message = "Nenhum registro encontrado!" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("BuscarPorId - erro: " + ex);
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Inserir usuário
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere um novo usuário na base
        /// </remarks>
        /// <param name="usuarioModel">Objeto do usuário</param>
        /// <returns></returns>
        //POST api/usuario/Inserir
        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir([FromBody] UsuarioModel usuarioModel)
        {
            _logger.LogDebug("Inserir - Iniciando");
            try
            {
                usuarioModel.Created = DateTime.Now;

                usuarioModel.Novo = true;

                var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);

                _usuarioAppServico.Adicionar(usuario);

                _logger.LogInformation("Inserir - Sucesso!");
                return Ok("Usuário inserido com sucesso!");

            }
            catch(Exception ex)
            {
                _logger.LogError("Inserir - erro: " + ex);
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Atualizar usuário
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Atualiza o usuário na base
        /// </remarks>
        /// <param name="usuarioModel">Objeto do usuário</param>
        /// <returns></returns>
        //PUT api/usuario/Atualizar
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] UsuarioModel usuarioModel)
        {
            _logger.LogDebug("Atualizar - Iniciando");
            try
            {
                usuarioModel.Modified = DateTime.Now;

                usuarioModel.Novo = false;

                var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);

                _usuarioAppServico.Atualizar(usuario);

                _logger.LogInformation("Atualizar - Sucesso!");
                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Atualizar - erro: " + ex);
                var response = new ObjectResponse
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError), response);
            }
        }

        /// <summary>
        /// Excluir usuário
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Exclui o usuário da base
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        //DELETE api/usuario/Excluir
        [HttpDelete]
        [Route("Excluir")]
        public IActionResult Excluir([FromQuery] int id)
        {
            _logger.LogDebug("Excluir - Iniciando");
            try
            {
                var usuario = _usuarioAppServico.BuscarPorId(id);

                if(usuario != null)
                {
                    _usuarioAppServico.Apagar(usuario);

                    _logger.LogInformation("Excluir - Sucesso!");
                    return Ok("Usuário apagado com sucesso!");
                }
                else
                {
                    _logger.LogWarning("Excluir - Nenhum registro encontrado!");
                    return NotFound(new { Status = HttpStatusCode.NotFound,
                    Message = "Nenhum registro encontrado!" });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Excluir - erro: " + ex);
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