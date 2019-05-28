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
    /// Controller CategoriaController
    /// </summary>
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppServico _categoriaAppServico;
        private readonly ILogger<CategoriaController> _logger;

        /// <summary>
        /// Construtor CategoriaController que gera a interface _categoriaAppServico
        /// </summary>
        /// <param name="categoriaAppServico"></param>
        /// <param name="logger"></param>
        public CategoriaController(ICategoriaAppServico categoriaAppServico, ILogger<CategoriaController> logger)
        {
            _categoriaAppServico = categoriaAppServico;
            _logger = logger;
        }

        /// <summary>
        /// Listar todos as categorias
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém a lista completa de categorias da Api
        /// </remarks>
        /// <returns></returns>
        //GET api/categoria/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            _logger.LogDebug("Listar - Iniciando");

            try
            {
                var categorias = _categoriaAppServico.BuscarTodos();

                if (categorias != null && categorias.Count() > 0)
                {
                    _logger.LogInformation("Listar - Sucesso!");
                    return Ok(categorias);
                }
                else
                {
                    _logger.LogWarning("Listar - Nenhum registro encontrado!");
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
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
        /// Listar categoria pelo Id
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém a categoria através do seu Id
        /// </remarks>
        /// <param name="id">Id da categoria</param>
        /// <returns></returns>
        //GET api/categoria/BuscarPorId?id={id}
        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId([FromQuery] int id)
        {
            _logger.LogDebug("BuscarPorId - Iniciando");
            try
            {
                var categoria = _categoriaAppServico.BuscarPorId(id);

                if (categoria != null)
                {
                    _logger.LogInformation("BuscarPorId - Sucesso!");
                    return Ok(categoria);
                }
                else
                {
                    _logger.LogWarning("BuscarPorId - Nenhum registro encontrado!");
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
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
        /// Inserir categoria
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere uma nova categoria na base
        /// </remarks>
        /// <param name="categoriaModel">Objeto da categoria</param>
        /// <returns></returns>
        //POST api/categoria/Inserir
        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir([FromBody] CategoriaModel categoriaModel)
        {
            _logger.LogDebug("Inserir - Iniciando");
            try
            {
                categoriaModel.Created = DateTime.Now;

                categoriaModel.Novo = true;

                var categoria = Mapper.Map<CategoriaModel, Categoria>(categoriaModel);

                _categoriaAppServico.Adicionar(categoria);

                _logger.LogInformation("Inserir - Sucesso!");
                return Ok("Categoria inserida com sucesso!");
            }
            catch (Exception ex)
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
        /// Atualizar categoria
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Atualiza a categoria na base
        /// </remarks>
        /// <param name="categoriaModel">Objeto da categoria</param>
        /// <returns></returns>
        //PUT api/categoria/Atualizar
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] CategoriaModel categoriaModel)
        {
            _logger.LogDebug("Atualizar - Iniciando");
            try
            {
                categoriaModel.Modified = DateTime.Now;

                categoriaModel.Novo = false;

                var categoria = Mapper.Map<CategoriaModel, Categoria>(categoriaModel);

                _categoriaAppServico.Atualizar(categoria);

                _logger.LogInformation("Atualizar - Sucesso!");
                return Ok("Categoria atualizada com sucesso!");
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
        /// Excluir categoria
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Exclui a categoria da base
        /// </remarks>
        /// <param name="id">Id da categoria</param>
        /// <returns></returns>
        //DELETE api/categoria/Excluir
        [HttpDelete]
        [Route("Excluir")]
        public IActionResult Excluir([FromQuery] int id)
        {
            _logger.LogDebug("Excluir - Iniciando");
            try
            {
                var categoria = _categoriaAppServico.BuscarPorId(id);

                if (categoria != null)
                {
                    _categoriaAppServico.Apagar(categoria);

                    _logger.LogInformation("Excluir - Sucesso!");
                    return Ok("Categoria apagada com sucesso!");
                }
                else
                {
                    _logger.LogWarning("Excluir - Nenhum registro encontrado!");
                    return NotFound(new
                    {
                        Status = HttpStatusCode.NotFound,
                        Message = "Nenhum registro encontrado!"
                    });
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