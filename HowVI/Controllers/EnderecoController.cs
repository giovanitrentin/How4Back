using Entities.Contracts;
using Entities.Entities;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers.HowVI
{
    [Route("Endereco")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IService _service;

        public EnderecoController(IEnderecoRepository enderecoRepository, IService service)
        {
            _service = service;
            _enderecoRepository = enderecoRepository;
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token, [FromBody] Endereco endereco)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (endereco != null && endereco.Id > 0)
                {
                    _enderecoRepository.Remover(endereco);
                    return Ok();
                }

                return NotFound("Endereco não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] Endereco endereco)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }
            try
            {
                if (endereco != null && endereco.Id > 0)
                {
                    endereco.DataAlteracao = DateTime.Now;
                    endereco.UsuarioAlteracao = vendedor.Id;
                    endereco = _enderecoRepository.Atualizar(endereco);
                    return endereco;
                }

                return NotFound("Endereco não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] Endereco endereco)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (endereco != null)
                {
                    endereco.DataAlteracao = DateTime.Now;
                    endereco.UsuarioAlteracao = vendedor.Id;
                    endereco.DataCriacao = DateTime.Now;
                    endereco.UsuarioCriacao = endereco.UsuarioAlteracao;
                    endereco = _enderecoRepository.Adicionar(endereco);
                    if (endereco.Id > 0)
                    {
                        return endereco;
                    }
                }

                return NotFound("Endereco não Inserido!");
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
                    var endereco = _enderecoRepository.ObterPorId(Id);
                    if (endereco != null)
                    {
                        return endereco;
                    }
                }

                return NotFound("Endereco não existe!");
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
                var endereco = _enderecoRepository.ObterTodos();
                if (endereco != null)
                {
                    return endereco;
                }

                return NotFound("Endereco não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}