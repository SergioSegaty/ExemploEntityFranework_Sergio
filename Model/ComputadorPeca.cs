using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("computadores_pecas")]
    public class ComputadorPeca: Base
    {
        [ForeignKey("IdPeca")]
        public Peca Peca { get; set; }

        [Column("id_peca")]
        public int IdPeca { get; set; }

        [ForeignKey("IdComputador")]
        public Computador Computador { get; set; }

        [Column("id_computador")]
        public int IdComputador { get; set; }
    }
}
