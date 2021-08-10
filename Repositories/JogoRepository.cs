using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> _jogos = new Dictionary<Guid, Jogo>
        {
            //Mock simulando BD
            {Guid.Parse("ae0c9197-ac61-47fb-a924-6c8e25429696"), new Jogo{ Id = Guid.Parse("ae0c9197-ac61-47fb-a924-6c8e25429696"), Nome = "jogo 1", Produtora = "Produtora 1", Preco = 10 } },
            {Guid.Parse("8344a6b1-5087-459e-b4ed-0ab7a1ac237e"), new Jogo{ Id = Guid.Parse("8344a6b1-5087-459e-b4ed-0ab7a1ac237e"), Nome = "jogo 2", Produtora = "Produtora 1", Preco = 102 } },
            {Guid.Parse("a4a45660-6dc4-4cd7-ac5b-6abea919a817"), new Jogo{ Id = Guid.Parse("a4a45660-6dc4-4cd7-ac5b-6abea919a817"), Nome = "jogo 3", Produtora = "Produtora 2", Preco = 102 } },
            {Guid.Parse("06b4e76c-2569-4bc5-a4cb-c45d00539062"), new Jogo{ Id = Guid.Parse("06b4e76c-2569-4bc5-a4cb-c45d00539062"), Nome = "jogo 4", Produtora = "Produtora 3", Preco = 103} },
            {Guid.Parse("4438bee6-5d25-404b-a1c7-82d8c2729007"), new Jogo{ Id = Guid.Parse("4438bee6-5d25-404b-a1c7-82d8c2729007"), Nome = "jogo 5", Produtora = "Produtora 2", Preco = 101 } },
            
            {Guid.Parse("4acb0979-f0ac-4537-bf2a-08bf48649aaa"), new Jogo{ Id = Guid.Parse("4acb0979-f0ac-4537-bf2a-08bf48649aaa"), Nome = "jogo 6", Produtora = "Produtora 1", Preco = 110 } },
            {Guid.Parse("e1870824-d943-475d-9882-a14f39d8fa0e"), new Jogo{ Id = Guid.Parse("e1870824-d943-475d-9882-a14f39d8fa0e"), Nome = "jogo 7", Produtora = "Produtora 1", Preco = 210 } },
            {Guid.Parse("a13ad1a3-4c99-452e-a178-25b827a987ee"), new Jogo{ Id = Guid.Parse("a13ad1a3-4c99-452e-a178-25b827a987ee"), Nome = "jogo 8", Produtora = "Produtora 2", Preco = 310 } },
            {Guid.Parse("ee0474fb-6286-4eb4-9604-dd974d421c3b"), new Jogo{ Id = Guid.Parse("ee0474fb-6286-4eb4-9604-dd974d421c3b"), Nome = "jogo 9", Produtora = "Produtora 3", Preco = 410 } },
            {Guid.Parse("2699d9a8-2e3a-46d7-b919-ffe1c8171e0c"), new Jogo{ Id = Guid.Parse("2699d9a8-2e3a-46d7-b919-ffe1c8171e0c"), Nome = "jogo 10", Produtora = "Produtora 2", Preco = 510 } }

        };

        public Task Atualizar(Jogo jogo)
        {
            _jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            ///
        }

        public Task Inserir(Jogo jogo)
        {
            _jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(_jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid idJogo)
        {
            if (!_jogos.ContainsKey(idJogo))
                return null;
            return Task.FromResult(_jogos[idJogo]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(_jogos.Values.Where(j => j.Nome.Equals(nome) && j.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid idJogo)
        {
            _jogos.Remove(idJogo);
            return Task.CompletedTask;
        }

    }
}
