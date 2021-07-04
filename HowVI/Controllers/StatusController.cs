using Entities.Contracts;
using Entities.Entities;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers.HowVI
{
    [Route("Status")]
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IService _service;

        public StatusController(IStatusRepository statusRepository, IService service)
        {
            _service = service;
            _statusRepository = statusRepository;
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token, [FromBody] Status status)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (status != null && status.Id > 0)
                {
                    _statusRepository.Remover(status);
                    return Ok();
                }

                return NotFound("Status não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] Status status)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }
            try
            {
                if (status != null && status.Id > 0)
                {
                    status.DataAlteracao = DateTime.Now;
                    status.UsuarioAlteracao = vendedor.Id;
                    status = _statusRepository.Atualizar(status);
                    return status;
                }

                return NotFound("Status não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] Status status)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }
            try
            {
                if (status != null)
                {
                    status.DataAlteracao = DateTime.Now;
                    status.UsuarioAlteracao = vendedor.Id;
                    status.DataCriacao = DateTime.Now;
                    status.UsuarioCriacao = status.UsuarioAlteracao;
                    status = _statusRepository.Adicionar(status);
                    if (status.Id > 0)
                    {
                        return status;
                    }
                }

                return NotFound("Status não Inserido!");
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
                    var status = _statusRepository.ObterPorId(Id);
                    if (status != null)
                    {
                        return status;
                    }
                }

                return NotFound("Status não existe!");
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
                var status = _statusRepository.ObterTodos();
                if (status != null)
                {
                    return status;
                }

                return NotFound("Status não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}