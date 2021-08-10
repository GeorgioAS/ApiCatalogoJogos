using System;
using System.Runtime.Serialization;

namespace ApiCatalogoJogos.Exceptions
{
    [Serializable]
    internal class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException() : base("Este jogo não esta cadastrado.")
        {
        }
    }
}