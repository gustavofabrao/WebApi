using Negocio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacao.Dtos
{
    public class GetContatoDto : ContatoDto
    {
        public GetContatoDto(Contato contato)
        {
            this.Nome = contato.Nome;
            this.Numero = contato.Endereco.Numero;
            this.Telefone = contato.Telefone;
            this.Bairro = contato.Endereco.Bairro;
            this.Cidade = contato.Endereco.Cidade;
            this.Cpf = contato.Cpf.ToString();
            this.Email = contato.Email;
        
        }
    }
}