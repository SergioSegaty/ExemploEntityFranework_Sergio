using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("computadores")]
    public class Computador: Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }
        
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }
    }
}
