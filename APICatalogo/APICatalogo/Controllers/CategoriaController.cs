using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Context;
using APICatalogo.Model;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _contexto;

        public CategoriaController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public ActionResult AdicionarCategoria([FromBody] Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);
            _contexto.SaveChanges();

            return new CreatedAtRouteResult("BuscarCategoriaPorCodigo", new { Codigo = categoria.CategoriaId, categoria });
        }

        [HttpPut("{codigo}")]
        public ActionResult<Categoria> AlterarCategoria(int codigo, [FromBody] Categoria categoria)
        {
            if ( codigo != categoria.CategoriaId )
            {
                return BadRequest();
            }

            _contexto.Entry(categoria).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> BuscarTudo()
        {
            return _contexto.Categorias.AsNoTracking().Include(item => item.Produtos).ToList();
        }

        [HttpGet("{codigo}", Name = "BuscarCategoriaPorCodigo")]
        public ActionResult<Categoria> BuscarCategoriaPorCodigo(int codigo)
        {
            Categoria categoria = _contexto.Categorias.AsNoTracking().FirstOrDefault(Categoria => Categoria.CategoriaId == codigo);

            if ( categoria == null )
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpDelete("{codigo}")]
        public ActionResult<Categoria> ExcluirCategoria(int codigo)
        {
            Categoria categoria = _contexto.Categorias.Find(codigo);

            if ( categoria == null )
            {
                return NotFound();
            }

            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();

            return Ok();
        }

    }
}
