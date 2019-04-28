using Aplicacao.App_Start;
using Aplicacao.Dtos;
using Negocio.Entidades;
using Negocio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aplicacao.Controllers
{
    [RoutePrefix("api/contato")]
    public class ContatoController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetContato()
        {
            // BadRequest(); -- 400
            // InternalServerError - 500
            // Ok - 200
            // NotFound -- 404
            Servico contatoServico = new Servico();

            List<GetContatoDto> retorno = new List<GetContatoDto>();
            foreach(Contato contato in contatoServico.RetornaTodosContato())
            {
                retorno.Add(new GetContatoDto(contato)); 
            }
            return Ok(retorno) ;
        }

        [HttpPost]
        [Route("")]
        [ValidacaoDto]
        public IHttpActionResult PostContato([FromBody] PostContatoDto dto)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);

            Servico contatoServico = new Servico();
            Contato contato = new Contato()
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Cpf = long.Parse(dto.Cpf),
                Email = dto.Email,
                Endereco = new Endereco()
                {
                    Bairro = dto.Bairro,
                    Cep = dto.Cep,
                    Cidade = dto.Cidade,
                    Estado = dto.Estado,
                    Logradouro = dto.Logradouro,
                    Numero = dto.Numero
                }
            };


            if (contatoServico.NovoContato(contato))
            {
                //return Ok("Inserido com sucesso");
                return Ok(contato);
            }
            else
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidacaoDto]
        public IHttpActionResult PutContato(int id, [FromBody] PutContatoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Servico contatoServico = new Servico();
            var contato = contatoServico.RetornaContato(id);
            if (contato == null)
                return NotFound();

            Contato entidade = new Contato()
            {
                ContatoId = id,
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Cpf = long.Parse(dto.Cpf),
                Email = dto.Email,
                Endereco = new Endereco()
                {
                    Bairro = dto.Bairro,
                    Cep = dto.Cep,
                    Cidade = dto.Cidade,
                    Estado = dto.Estado,
                    Logradouro = dto.Logradouro,
                    Numero = dto.Numero
                }
            };

            if (contatoServico.AtualizarContato(entidade))
            {
                //return Ok("Contato atualizado com sucesso!");
                return Ok(contato);
            }
            else
            {
                return InternalServerError();
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        [ValidacaoDto]
        public IHttpActionResult DeleteContato(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Servico contatoServico = new Servico();
            var contato = contatoServico.RetornaContato(id);
            if (contato == null)
                return NotFound();

            Contato entidade = new Contato();
            entidade.Status = 0;

            if (contatoServico.AtualizarContato(entidade))
            {
                //return Ok("Contato atualizado com sucesso!");
                return Ok(contato);
            }
            else
            {
                return InternalServerError();
            }
        }


        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetContatoPorId(int id)
        {
            Servico contatoServico = new Servico();
            
            var contato = contatoServico.RetornaContato(id);
            if (contato == null)
                return NotFound();

            var contatodto = new GetContatoDto(contato);
            return Ok(contato);
        }
    }
}
