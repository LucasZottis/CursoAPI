using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoApi.Models
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public double Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}