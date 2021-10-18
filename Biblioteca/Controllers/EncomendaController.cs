using Biblioteca.Context;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncomendaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EncomendaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Encomendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encomenda>>> GetEncomendas()
        {
            return await _context.Encomenda.ToListAsync();
        }

        // GET: api/Encomendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encomenda>> GetEncomenda(int id)
        {
            var encomenda = await _context.Encomenda.FindAsync(id);

            if (encomenda == null)
            {
                return NotFound();
            }

            return encomenda;
        }

        // PUT: api/Encomendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncomenda(int id, Encomenda encomenda)
        {
            if (id != encomenda.ID)
            {
                return BadRequest();
            }

            _context.Entry(encomenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncomendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Encomendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encomenda>> PostEncomenda(int IDProduto, int IDEquipe, string EnderecoEntrega)
        {
            Produto produto = _context.Produto.Find(IDProduto);
            List<Produto> produtos = new List<Produto>();
            produtos.Add(produto);
            Pedido pedido = new Pedido() { DataCriacao = DateTime.Now, Endereco = EnderecoEntrega, Produtos = produtos };
            Equipe equipe = _context.Equipe.Find(IDEquipe);
            Encomenda encomenda = new Encomenda() { Equipe = equipe, Pedido = pedido };
            _context.Encomenda.Add(encomenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncomenda", new { id = encomenda.ID }, encomenda);
        }

        // DELETE: api/Encomendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncomenda(int id)
        {
            var encomenda = await _context.Encomenda.FindAsync(id);
            if (encomenda == null)
            {
                return NotFound();
            }

            _context.Encomenda.Remove(encomenda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncomendaExists(int id)
        {
            return _context.Encomenda.Any(e => e.ID == id);
        }
    }
}
