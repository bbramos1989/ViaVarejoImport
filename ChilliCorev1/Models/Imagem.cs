using System;
using System.Collections.Generic;

namespace ChilliCorev1.Models
{
    public partial class Imagem
    {
        public int Id { get; set; }
        public string CodigoImagem { get; set; }
        public int Ordem { get; set; }
        public int? ProdutoId { get; set; }
        public string Url { get; set; }

        public Produtos Produto { get; set; }
    }
}
