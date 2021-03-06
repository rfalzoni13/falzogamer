﻿using AutoMapper;
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
    /// Controller Produto Controller
    /// </summary>
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppServico _produtoAppServico;
        private readonly ILogger<ProdutoController> _logger;

        /// <summary>
        /// Construtor ProdutoController que gera a interface _produtoAppServico
        /// </summary>
        /// <param name="produtoAppServico"></param>
        /// <param name="logger"></param>
        public ProdutoController(IProdutoAppServico produtoAppServico, ILogger<ProdutoController> logger)
        {
            _produtoAppServico = produtoAppServico;
            _logger = logger;
        }

        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém a lista completa de produtos da Api
        /// </remarks>
        /// <returns></returns>
        //GET api/produto/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            _logger.LogDebug("Listar - Iniciando");
            try
            {
                var produtos = _produtoAppServico.BuscarTodos();

                if (produtos != null && produtos.Count() > 0)
                {
                    _logger.LogInformation("Listar - Sucesso!");
                    return Ok(produtos);
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
        /// Listar produto pelo Id
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Obtém o produto através do seu Id
        /// </remarks>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        //GET api/produto/BuscarPorId?id={id}
        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId([FromQuery] int id)
        {
            _logger.LogDebug("BuscarPorId - Iniciando");
            try
            {
                var produto = _produtoAppServico.BuscarPorId(id);

                if (produto != null)
                {
                    _logger.LogInformation("BuscarPorId - Sucesso!");
                    return Ok(produto);
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
        /// Inserir produto
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Insere um novo produto na base
        /// </remarks>
        /// <param name="produtoModel">Objeto do produto</param>
        /// <returns></returns>
        //POST api/produto/Inserir
        [HttpPost]
        [Route("Inserir")]
        public IActionResult Inserir([FromBody] ProdutoModel produtoModel)
        {
            _logger.LogDebug("Inserir - Iniciando");
            try
            {
                produtoModel.Created = DateTime.Now;

                produtoModel.Novo = true;

                var produto = Mapper.Map<ProdutoModel, Produto>(produtoModel);

                _produtoAppServico.Adicionar(produto);

                _logger.LogInformation("Inserir - Sucesso!");
                return Ok("Produto inserido com sucesso!");
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
        /// Atualizar produto
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Atualiza o produto na base
        /// </remarks>
        /// <param name="produtoModel">Objeto do produto</param>
        /// <returns></returns>
        //PUT api/produto/Atualizar
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] ProdutoModel produtoModel)
        {
            _logger.LogDebug("Atualizar - Iniciando");
            try
            {
                produtoModel.Modified = DateTime.Now;

                produtoModel.Novo = false;

                var produto = Mapper.Map<ProdutoModel, Produto>(produtoModel);

                _produtoAppServico.Atualizar(produto);

                _logger.LogInformation("Atualizar - Sucesso!");
                return Ok("Produto atualizado com sucesso!");
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
        /// Excluir produto
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>
        /// Exclui o produto da base
        /// </remarks>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        //DELETE api/produto/Excluir
        [HttpDelete]
        [Route("Excluir")]
        public IActionResult Excluir([FromQuery] int id)
        {
            _logger.LogDebug("Excluir - Iniciando");
            try
            {
                var produto = _produtoAppServico.BuscarPorId(id);

                if (produto != null)
                {
                    _produtoAppServico.Apagar(produto);

                    _logger.LogInformation("Excluir - Sucesso!");
                    return Ok("Produto apagado com sucesso!");
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