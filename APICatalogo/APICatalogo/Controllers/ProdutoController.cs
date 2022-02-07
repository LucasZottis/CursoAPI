using APICatalogo.Context;
using APICatalogo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _contexto;

        public ProdutoController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public ActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                _contexto.Produtos.Add(produto);
                _contexto.SaveChanges();

                return new CreatedAtRouteResult("BuscarProdutoPorCodigo", new { Codigo = produto.ProdutoId, produto });
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível realizar a operação.");
            }
        }

        [HttpPut("{codigo}")]
        public ActionResult<Produto> AlterarProduto(int codigo, [FromBody] Produto produto)
        {
            try
            {
                if ( codigo == 0 || codigo != produto.ProdutoId )
                {
                    return BadRequest($"Não foi possível localizar o produto com código {codigo}");
                }

                _contexto.Entry(produto).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Ok("Produto alterado com sucesso.");
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível realizar a operação.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> BuscarTudo()
        {
            try
            {
                return _contexto.Produtos.AsNoTracking().Include(item => item.Categoria).ToList();
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível realizar a operação.");
            }
        }

        [HttpGet("{codigo}", Name = "BuscarProdutoPorCodigo")]
        public ActionResult<Produto> BuscarProdutoPorCodigo(int codigo)
        {
            try
            {
                Produto produto = _contexto.Produtos.AsNoTracking().FirstOrDefault(produto => produto.ProdutoId == codigo);

                if ( produto == null )
                {
                    return NotFound($"Não foi possível localizar o produto com código {codigo}");
                }

                return produto;
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível realizar a operação.");
            }
        }

        [HttpDelete("{codigo}")]
        public ActionResult<Produto> ExcluirProduto(int codigo)
        {
            try
            {
                Produto produto = _contexto.Produtos.Find(codigo);

                if ( produto == null )
                {
                    return NotFound($"Não foi possível localizar o produto com código: {codigo}");
                }

                _contexto.Produtos.Remove(produto);
                _contexto.SaveChanges();

                return Ok("Produto excluído com sucesso.");
            }
            catch ( Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possível realizar a operação.");
            }
        }
    }
}