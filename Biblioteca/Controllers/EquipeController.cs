using Biblioteca.Context;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return equipe;
        }

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipe>> PostEquipe(string nome, string descricao, string placaVeiculo)
        {
            Equipe equipe = new Equipe() { Nome = nome, Descricao = descricao, PlacaVeiculo = placaVeiculo };
            _context.Equipe.Add(equipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipe", new { id = equipe.ID }, equipe);
        }
    }
}
