using System;
using System.Collections.Generic;

namespace ChilliCorev1.Models
{
    public partial class CategoriaProdutos
    {
        public int Id { get; set; }
        public int? CategoriaId { get; set; }
        public int? ProdutoId { get; set; }

        public Categorias Categoria { get; set; }
        public Produtos Produto { get; set; }
    }
}
