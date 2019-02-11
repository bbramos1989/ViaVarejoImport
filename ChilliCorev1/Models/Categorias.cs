using System;
using System.Collections.Generic;

namespace ChilliCorev1.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            CategoriaProdutos = new HashSet<CategoriaProdutos>();
            InverseCategoria = new HashSet<Categorias>();
            Produtos = new HashSet<Produtos>();
        }

        public int Id { get; set; }
        public int? CategoriaId { get; set; }
        public string CodigoCategoria { get; set; }
        public int Level { get; set; }
        public string Nome { get; set; }
        public bool PossuiIcone { get; set; }

        public Categorias Categoria { get; set; }
        public ICollection<CategoriaProdutos> CategoriaProdutos { get; set; }
        public ICollection<Categorias> InverseCategoria { get; set; }
        public ICollection<Produtos> Produtos { get; set; }
    }
}
