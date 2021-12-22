using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CatalogoApi.Models
{
    public class Categoria
    {
        public int CodigoCategoria { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
    }
}
