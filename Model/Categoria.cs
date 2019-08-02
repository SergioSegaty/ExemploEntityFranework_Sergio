using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("categorias")]
    public class Categoria : Base
    {
        [Column("nome")]
        public string Nome { get; set; }
    }
}
