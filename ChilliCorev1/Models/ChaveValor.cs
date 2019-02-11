using System;
using System.Collections.Generic;

namespace ChilliCorev1.Models
{
    public partial class ChaveValor
    {
        public int Id { get; set; }
        public int? EspecificacaoId { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }

        public Especificacao Especificacao { get; set; }
    }
}
