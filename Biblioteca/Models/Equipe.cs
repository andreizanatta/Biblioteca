using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Equipe
    {
        public Equipe()
        {

        }

        public Equipe(string Nome, string Descricao, string PlacaVeiculo)
        {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.PlacaVeiculo = PlacaVeiculo;
        }

        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PlacaVeiculo { get; set; }
    }
}
