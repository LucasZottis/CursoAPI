using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoApi.Models
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        [Column("COD_CATEGORIA")]
        public int CodigoCategoria { get; set; }

        [Required]
        [Column("NOME")]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [Column("URL_IMAGEM")]
        [MaxLength(300)]
        public string Imagem { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
    }
}
