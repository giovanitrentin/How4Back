using Entities.Contracts;
using Entities.Entities;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers.HowVI
{
    [Route("TipoContato")]
    public class TipoContatoController : Controller
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;
        private readonly IService _service;

        public TipoContatoController(ITipoContatoRepository tipoContatoRepository, IService service)
        {
            _service = service;
            _tipoContatoRepository = tipoContatoRepository;
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token, [FromBody] TipoContato tipoContato)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (tipoContato != null && tipoContato.Id > 0)
                {
                    _tipoContatoRepository.Remover(tipoContato);
                    return Ok();
                }

                return NotFound("TipoContato não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] TipoContato tipoContato)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (tipoContato != null && tipoContato.Id > 0)
                {
                    tipoContato.DataAlteracao = DateTime.Now;
                    tipoContato.UsuarioAlteracao = vendedor.Id;
                    tipoContato = _tipoContatoRepository.Atualizar(tipoContato);
                    return tipoContato;
                }

                return NotFound("TipoContato não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] TipoContato tipoContato)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (tipoContato != null)
                {
                    tipoContato.DataAlteracao = DateTime.Now;
                    tipoContato.UsuarioAlteracao = vendedor.Id;
                    tipoContato.DataCriacao = DateTime.Now;
                    tipoContato.UsuarioCriacao = tipoContato.UsuarioAlteracao;

                    tipoContato = _tipoContatoRepository.Adicionar(tipoContato);

                    if (tipoContato.Id > 0)
                    {
                        return tipoContato;
                    }
                }

                return NotFound("TipoContato não Inserido!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<dynamic> Get([FromHeader] string token, int Id)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (Id > 0)
                {
                    var tipoContato = _tipoContatoRepository.ObterPorId(Id);
                    if (tipoContato != null)
                    {
                        return tipoContato;
                    }
                }

                return NotFound("TipoContato não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpGet]
        public object Get([FromHeader] string token)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }
            try
            {
                var tipoContato = _tipoContatoRepository.ObterTodos();
                if (tipoContato != null)
                {
                    return tipoContato;
                }

                return NotFound("TipoContato não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}