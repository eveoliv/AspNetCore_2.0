using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel
    {
        [Key]
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Produto : BaseModel
    {
        public Produto(){}
        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public decimal Preco { get; private set; }

        public Produto(string codigo, string nome, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }
    }

    public class Cadastro : BaseModel
    {
        public Cadastro(){}

        public virtual Pedido Pedido { get; set; }
        
        [MinLength(5, ErrorMessage = "Nome deve ter no minimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no maximo 50 caracteres")]
        [Required(ErrorMessage = "Nome � obrigatorio")]
        public string Nome { get; set; } = "";
        [Required(ErrorMessage = "Email � obrigatorio")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Telefone � obrigatorio")]
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "Endere�o � obrigatorio")]
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "Complemento � obrigatorio")]
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "Bairro � obrigatorio")]
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "Municipio � obrigatorio")]
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "UF � obrigatorio")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "CEP � obrigatorio")]
        public string CEP { get; set; } = "";

        internal void Update(Cadastro novoCadastro)
        {
            Nome = novoCadastro.Nome;
            Email = novoCadastro.Email;
            Telefone = novoCadastro.Telefone;
            Endereco = novoCadastro.Endereco;
            Complemento = novoCadastro.Complemento;
            Bairro = novoCadastro.Bairro;
            Municipio = novoCadastro.Municipio;
            UF = novoCadastro.UF;
            CEP = novoCadastro.CEP;
        }
    }

    [DataContract]
    public class ItemPedido : BaseModel
    {   
        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }
        [Required]
        [DataMember]
        public Produto Produto { get; private set; }
        [Required]
        [DataMember]
        public int Quantidade { get; private set; }
        [Required]
        [DataMember]
        public decimal PrecoUnitario { get; private set; }
        [DataMember]
        public decimal Subtotal => Quantidade * PrecoUnitario;

        public ItemPedido(){}

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }

    public class Pedido : BaseModel
    {        
        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();
        [Required]
        public virtual Cadastro Cadastro { get; private set; }
    }
}
