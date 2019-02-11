using System;
using System.Collections.Generic;

namespace ChilliCorev1.Models
{
    public partial class Especificacao
    {
        public Especificacao()
        {
            ChaveValor = new HashSet<ChaveValor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? ProdutoId { get; set; }

        public Produtos Produto { get; set; }
        public ICollection<ChaveValor> ChaveValor { get; set; }
    }
}
