using Entities.Contracts;
using Entities.Entities;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers.HowVI
{
    [Route("ContatoCliente")]
    public class ContatoClienteController : Controller
    {
        private readonly IContatoClienteRepository _contatoClienteRepository;
        private readonly IService _service;

        public ContatoClienteController(IContatoClienteRepository contatoClienteRepository, IService service)
        {
            _service = service;
            _contatoClienteRepository = contatoClienteRepository;
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token, [FromBody] ContatoCliente contatoCliente)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (contatoCliente != null && contatoCliente.Id > 0)
                {
                    _contatoClienteRepository.Remover(contatoCliente);
                    return Ok();
                }

                return NotFound("ContatoCliente não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] ContatoCliente contatoCliente)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (contatoCliente != null && contatoCliente.Id > 0)
                {
                    contatoCliente.DataAlteracao = DateTime.Now;
                    contatoCliente.UsuarioAlteracao = vendedor.Id;
                    contatoCliente = _contatoClienteRepository.Atualizar(contatoCliente);
                    return contatoCliente;
                }

                return NotFound("ContatoCliente não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] ContatoCliente contatoCliente)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (contatoCliente != null)
                {
                    contatoCliente.DataAlteracao = DateTime.Now;
                    contatoCliente.UsuarioAlteracao = vendedor.Id;
                    contatoCliente.DataCriacao = DateTime.Now;
                    contatoCliente.UsuarioCriacao = contatoCliente.UsuarioAlteracao;
                    contatoCliente = _contatoClienteRepository.Adicionar(contatoCliente);
                    if (contatoCliente.Id > 0)
                    {
                        return contatoCliente;
                    }
                }

                return NotFound("ContatoCliente não Inserido!");
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
                    var contatoCliente = _contatoClienteRepository.ObterPorId(Id);
                    if (contatoCliente != null)
                    {
                        return contatoCliente;
                    }
                }

                return NotFound("ContatoCliente não existe!");
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
                var contatoCliente = _contatoClienteRepository.ObterTodos();
                if (contatoCliente != null)
                {
                    return contatoCliente;
                }

                return NotFound("ContatoCliente não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}