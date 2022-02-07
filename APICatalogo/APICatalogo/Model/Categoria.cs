using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Model
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        [Column("COD_CATEGORIA")]
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(80)]
        [Column("NOME_CATEGORIA")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("URL_IMAGEM")]
        public string ImagemUrl { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
    }
}
