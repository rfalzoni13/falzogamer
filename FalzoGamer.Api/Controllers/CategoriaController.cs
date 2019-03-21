using AutoMapper;
using FalzoGamer.Api.DTOs;
using FalzoGamer.Api.Models;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace FalzoGamer.Api.Controllers
{
    /// <summary>
    /// Controller CategoriaController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppServico _categoriaAppServico;

        /// <summary>
        /// Construtor CategoriaController que gera a interface _categoriaAppServico
        /// </summary>
        /// <param name="categoriaAppServico"></param>
        public CategoriaController(ICategoriaAppServico categoriaAppServico)
        {
            _categoriaAppServico = categoriaAppServico;
        }

        /// <summary>
        /// Listar todos as categorias
        /// </summary>
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
            try
            {
                var categorias = _categoriaAppServico.BuscarTodos();

                if (categorias != null && categorias.Count() > 0)
                {
                    return Ok(categorias);
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
        /// Listar categoria pelo Id
        /// </summary>
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
            try
            {
                var categoria = _categoriaAppServico.BuscarPorId(id);

                if (categoria != null)
                {
                    return Ok(categoria);
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
        /// Inserir categoria
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere uma nova categoria na base
        /// </remarks>
        /// <param name="categoriaDTO">Objeto da categoria</param>
        /// <returns></returns>
        //POST api/categoria/Inserir
        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                categoriaDTO.Created = DateTime.Now;

                categoriaDTO.Novo = true;

                var categoria = Mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);

                _categoriaAppServico.Adicionar(categoria);

                return Ok("Categoria inserida com sucesso!");
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
        /// Atualizar categoria
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Atualiza a categoria na base
        /// </remarks>
        /// <param name="categoriaDTO">Objeto da categoria</param>
        /// <returns></returns>
        //PUT api/categoria/Atualizar
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                categoriaDTO.Modified = DateTime.Now;

                categoriaDTO.Novo = false;

                var categoria = Mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);

                _categoriaAppServico.Atualizar(categoria);

                return Ok("Categoria atualizada com sucesso!");
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
        /// Excluir categoria
        /// </summary>
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
            try
            {
                var categoria = _categoriaAppServico.BuscarPorId(id);

                if (categoria != null)
                {
                    _categoriaAppServico.Apagar(categoria);

                    return Ok("Categoria apagada com sucesso!");
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