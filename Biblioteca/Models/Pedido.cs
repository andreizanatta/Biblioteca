using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Pedido
    {
        public Pedido()
        {

        }

        public Pedido(string Endereco, ICollection<Produto> Produtos, DateTime dataCriacao)
        {
            this.DataCriacao = dataCriacao;
            this.Endereco = Endereco;
            this.Produtos = Produtos;
        }
         
        [Key]
        public int ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntregaRealizada { get; set; }
        public string Endereco { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
