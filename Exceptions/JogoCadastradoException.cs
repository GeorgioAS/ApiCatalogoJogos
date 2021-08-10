using System;
using System.Runtime.Serialization;

namespace ApiCatalogoJogos.Exceptions
{
    [Serializable]
    internal class JogoCadastradoException : Exception
    {
        public JogoCadastradoException() : base("Este Jogo já esta cadastrado.")
        {
        }
    }
}