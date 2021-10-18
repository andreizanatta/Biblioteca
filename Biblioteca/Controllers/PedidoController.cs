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
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Pedido>> GetAsync()
        {
            Produto produto = new Produto() { Nome = "Detergente", Descricao = "Detergente Neutro", Valor = 2.6M };
            _context.Produto.Add(produto);
            Produto produto2 = new Produto() { Nome = "Mouse", Descricao = "Mouse Óptico", Valor = 50M };
            _context.Produto.Add(produto2);
            Produto produto3 = new Produto() { Nome = "Água Sem Gás", Descricao = "Água Sem Gás", Valor = 2.5M };
            _context.Produto.Add(produto3);

            List<Produto> produtosPedido = new List<Produto>();
            produtosPedido.Add(produto);
            produtosPedido.Add(produto2);
            produtosPedido.Add(produto3);

            Pedido pedido = new Pedido() { Endereco = "Endereço padrão", Produtos = produtosPedido, DataCriacao = DateTime.Now };
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            Produto produto4 = new Produto() { Nome = "Tapete", Descricao = "Tapete Neutro", Valor = 200.6M };
            _context.Produto.Add(produto4);
            Produto produto5 = new Produto() { Nome = "Microondas", Descricao = "Microondas 220V", Valor = 500M };
            _context.Produto.Add(produto5);
            Produto produto6 = new Produto() { Nome = "Xícara", Descricao = "Xícara Personalizada", Valor = 22.5M };
            _context.Produto.Add(produto6);

            List<Produto> produtosPedido2 = new List<Produto>();
            produtosPedido2.Add(produto4);
            produtosPedido2.Add(produto5);
            produtosPedido2.Add(produto6);

            Pedido pedido2 = new Pedido() { Endereco = "Endereço padrão de entrega", Produtos = produtosPedido2, DataCriacao = DateTime.Now };
            _context.Pedido.Add(pedido2);
            await _context.SaveChangesAsync();

            Produto produto7 = new Produto() { Nome = "Quadro", Descricao = "Quadro 10x10", Valor = 29.6M };
            _context.Produto.Add(produto7);
            Produto produto8 = new Produto() { Nome = "Sofá", Descricao = "Sofá Cama", Valor = 50M };
            _context.Produto.Add(produto8);
            Produto produto9 = new Produto() { Nome = "Geladeira", Descricao = "Geladeira 220V", Valor = 25.5M };
            _context.Produto.Add(produto9);

            List<Produto> produtosPedido3 = new List<Produto>();
            produtosPedido3.Add(produto7);
            produtosPedido3.Add(produto8);
            produtosPedido3.Add(produto9);

            Pedido pedido3 = new Pedido() { Endereco = "Endereço padrão de entrega da cidade", Produtos = produtosPedido3, DataCriacao = DateTime.Now };
            _context.Pedido.Add(pedido3);
            await _context.SaveChangesAsync();

            return await _context.Pedido.OrderBy(p => p.DataCriacao).ToListAsync();
        }
    }
}
