using Negocio.Entidades;
using System.Collections.Generic;

namespace Negocio.Servicos
{
    public interface IServico
    {
        bool NovoContato(Contato contato);

        bool AtualizarContato(Contato contato);

        Contato RetornaContato(int contatoId);
        List<Contato> RetornaTodosContato();

        bool ExcluirContato(int contatoId);
    }
}