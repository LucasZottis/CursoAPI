using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Model
{
    [Table("PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("COD_PRODUTO")]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(80)]
        [Column("NOME_PRODUTO")]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        [Column("DES_PRODUTO")]
        public string Descricao { get; set; }

        [Column("VAL_PRODUTO")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(500)]
        [Column("URL_IMAGEM")]
        public string ImagemUrl { get; set; }

        [Column("QTD_ESTOQUE")]
        public float Estoque { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("COD_CATEGORIA")]
        public Categoria Categoria { get; set; }

        public Produto()
        {
            
        }
    }
}