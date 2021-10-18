using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Encomenda
    {
        public Encomenda()
        {

        }

        public Encomenda(Pedido pedido, Equipe equipe)
        {
            Pedido = pedido;
            Equipe = equipe;
        }

        [Key]
        public int ID { get; set; }
        public Pedido Pedido { get; set; }
        public Equipe Equipe { get; set; }
    }
}
