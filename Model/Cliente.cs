using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("clientes")]
    public class Cliente: Base
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }
    }
}