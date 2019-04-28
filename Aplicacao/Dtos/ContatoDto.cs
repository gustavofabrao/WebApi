using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacao.Dtos
{
    public class ContatoDto
    {
        [Required(ErrorMessage = "Nome Obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone Obrigatório")]
        [StringLength(12)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Cpf Obrigatório")]
        [RegularExpression(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$", ErrorMessage = "Cpf inválido")]
        public string Cpf { get; set; }

        [StringLength(100)]
        public string Logradouro { get; set; }

        [StringLength(6)]
        public string Numero { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [RegularExpression(@"^\d{5}\-?\d{3}$", ErrorMessage = "Cep inválido")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "Campo Cidade Obrigatório")]
        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        //[EmailAddress]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}