using Entities.Contracts;
using Entities.Entities;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controllers.HowVI
{
    [Route("Empresa")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IService _service;

        public EmpresaController(IEmpresaRepository empresaRepository, IService service)
        {
            _service = service;
            _empresaRepository = empresaRepository;
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token, [FromBody] Empresa empresa)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (empresa != null && empresa.Id > 0)
                {
                    _empresaRepository.Remover(empresa);
                    return Ok();
                }

                return NotFound("Empresa não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] Empresa empresa)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }
            try
            {
                if (empresa != null && empresa.Id > 0)
                {
                    empresa.DataAlteracao = DateTime.Now;
                    empresa.UsuarioAlteracao = vendedor.Id;
                    empresa = _empresaRepository.Atualizar(empresa);
                    return empresa;
                }

                return NotFound("Empresa não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] Empresa empresa)
        {
            Vendedor vendedor = _service.Autorizado(token);
            if (vendedor == null)
            {
                return Unauthorized();
            }

            try
            {
                if (empresa != null)
                {
                    empresa.DataAlteracao = DateTime.Now;
                    empresa.UsuarioAlteracao = vendedor.Id;
                    empresa.DataCriacao = DateTime.Now;
                    empresa.UsuarioCriacao = empresa.UsuarioAlteracao;
                    empresa = _empresaRepository.Adicionar(empresa);
                    if (empresa.Id > 0)
                    {
                        return empresa;
                    }
                }

                return NotFound("Empresa não Inserido!");
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
                    var empresa = _empresaRepository.ObterPorId(Id);
                    if (empresa != null)
                    {
                        return empresa;
                    }
                }

                return NotFound("Empresa não existe!");
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
                var empresa = _empresaRepository.ObterTodos();
                if (empresa != null)
                {
                    return empresa;
                }

                return NotFound("Empresa não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}