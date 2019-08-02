using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("pecas")]
    public class Peca: Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }
    }
}