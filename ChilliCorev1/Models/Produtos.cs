using System;
using System.Collections.Generic;

namespace ChilliCorev1.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            CategoriaProdutos = new HashSet<CategoriaProdutos>();
            Especificacao = new HashSet<Especificacao>();
            Imagem = new HashSet<Imagem>();
        }

        public int Id { get; set; }
        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Habilitado { get; set; }
        public int? CategoriaPrincipalId { get; set; }

        public Categorias CategoriaPrincipal { get; set; }
        public ICollection<CategoriaProdutos> CategoriaProdutos { get; set; }
        public ICollection<Especificacao> Especificacao { get; set; }
        public ICollection<Imagem> Imagem { get; set; }
    }
}
