using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(string Nome, string Descricao, decimal Valor)
        {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Valor = Valor;
        }

        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Valor { get; set; }
    }
}
