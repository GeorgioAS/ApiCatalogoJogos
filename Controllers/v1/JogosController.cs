using ApiCatalogoJogos.InputModel;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoServices _jogoservice;

        public JogosController(IJogoServices jogoservices)
        {
            _jogoservice = jogoservices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1,50)] int quantidade = 5)
        {
            var result = await _jogoservice.Obter(pagina , quantidade );
            if (result.Count() == 0)
                return NoContent();
            return Ok(result);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter(Guid id) 
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel Jogo)
        {
            return Ok();
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult<object>> AtualizarJogo(Guid idJogo, JogoInputModel Jogo)
        {
            return Ok();
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApaparJogo(Guid idJogo)
        {
            return Ok();
        }

    }
}
