using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicos
{
    public class Servico: IServico
    {
        List<Contato> contatos = new List<Contato>()
        {
            new Contato()
            {
                ContatoId = 1,
                Cpf = 39043723860,
                Nome = "Gustavo",
                Telefone = "99316-8852",
                Email = "gfabrao@gmail.com",
                Endereco = new Endereco()
                {
                    Bairro = "jd America",
                    Cep = 14470000,
                    Cidade = "Rib preto",
                    Estado = "SP",
                    Logradouro = "rua galileu",
                    Numero = "1423"
                }
            },
            new Contato()
            {
                ContatoId = 2,
                Cpf = 03006538838,
                Nome = "Abrão",
                Telefone = "99311-5500",
                Email = "abrao@gmail.com",
                Endereco = new Endereco()
                {
                    Bairro = "jd Irajá",
                    Cep = 14020620,
                    Cidade = "Rib Preto",
                    Estado = "SP",
                    Logradouro = "Rua Chile",
                    Numero = "123"
                }
            }
        };

        public bool AtualizarContato(Contato contato)
        {
            try
            {
                var index = contatos.FindIndex(p => p.ContatoId == contato.ContatoId);

                contatos[index] = contato;
                contatos[index].DataAlteracao = DateTime.Now;
                return true;
            }
            catch (Exception)
            {
                contato.Status = 0;
                return false;
            }
        }

        public bool ExcluirContato(int contatoId)
        {
            try
            {
                var objContato = RetornaContato(contatoId);
                contatos.Remove(objContato);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool NovoContato(Contato contato)
        {
            try
            {
                contato.DataCriacao = DateTime.Now;
                contato.Status = 1;
                contatos.Add(contato);
                return true;
            }
            catch (Exception)
            {
                contato.Status = 0;
                return false;
            }
            
        }

        public Contato RetornaContato(int contatoId)
        {
            return contatos.FirstOrDefault(p => p.ContatoId == contatoId);
        }

        public List<Contato> RetornaTodosContato()
        {
            return contatos;
        }
    }
}
