using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoApi.Models
{
    [Table("PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("COD_PRODUTO")]
        public int CodigoProduto { get; set; }

        [Required]
        [Column("NOME_PRODUTO")]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [Column("DES_PRODUTO")]
        [MaxLength(300)]
        public string Descricao { get; set; }

        [Required]
        [Column("VAL_PRODUTO")]
        public decimal Preco { get; set; }

        [Required]
        [Column("URL_IMAGEM")]
        [MaxLength(500)]
        public string Imagem { get; set; }

        [Column("QUANTIDADE_ESTOUE")]
        public double Estoque { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        public Categoria Categoria { get; set; }

        public int CodigoCategoria { get; set; }
    }
}