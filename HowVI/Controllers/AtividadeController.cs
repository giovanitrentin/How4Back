using Entities.Contracts;
using Entities.Entities;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers.HowVI
{
    [Route("Atividade")]
    public class AtividadeController : Controller
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IService _service;

        public AtividadeController(IAtividadeRepository atividadeRepository, IService service)
        {
            _service = service;
            _atividadeRepository = atividadeRepository;
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token, [FromBody] Atividade atividade)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (atividade != null && atividade.Id > 0)
                {
                    _atividadeRepository.Remover(atividade);
                    return Ok();
                }

                return NotFound("Atividade não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] Atividade atividade)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (atividade != null && atividade.Id > 0)
                {
                    atividade.DataAlteracao = DateTime.Now;
                    atividade.UsuarioAlteracao = vendedor.Id;
                    atividade = _atividadeRepository.Atualizar(atividade);
                    return atividade;
                }

                return NotFound("Atividade não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] Atividade atividade)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (atividade != null)
                {
                    atividade.DataAlteracao = DateTime.Now;
                    atividade.UsuarioAlteracao = vendedor.Id;
                    atividade.DataCriacao = DateTime.Now;
                    atividade.UsuarioCriacao = atividade.UsuarioAlteracao;
                    atividade = _atividadeRepository.Adicionar(atividade);
                    if (atividade.Id > 0)
                    {
                        return atividade;
                    }
                }

                return NotFound("Atividade não Inserido!");
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
                    var atividade = _atividadeRepository.ObterPorId(Id);
                    if (atividade != null)
                    {
                        return atividade;
                    }
                }

                return NotFound("Atividade não existe!");
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
                var atividade = _atividadeRepository.ObterTodos();
                if (atividade != null)
                {
                    return atividade;
                }

                return NotFound("Atividade não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}