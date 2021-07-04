using Entities.Contracts;
using Entities.Entities;
using HowVI.Arguments;
using HowVI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HowVI.Controllers
{
    [Route("Vendedor")]
    public class VendedorController : Controller
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IService _service;
        private static readonly Random random = new Random();

        public VendedorController(IVendedorRepository vendedorRepository, IService service)
        {
            _service = service;
            _vendedorRepository = vendedorRepository;
        }

        [HttpPost("Login")]
        public ActionResult<dynamic> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var vendedor = _vendedorRepository.ObterPorLogin(loginRequest.Login);

                if ((vendedor != null) && (vendedor.Senha.Equals(loginRequest.Senha)))
                {
                    vendedor.TokenAccess = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWYZabcdefghijklmnopkrstuvwyz1234567890", 24)
                                                .Select(s => s[random.Next(s.Length)]).ToArray());

                    vendedor = _vendedorRepository.Atualizar(vendedor);

                    return new LoginResponse()
                    {
                        IsAutenticado = true,
                        Validade = DateTime.Now.AddHours(2),
                        Token = vendedor.TokenAccess,
                        vendedor = vendedor
                    };
                }

                return Unauthorized();
            }
            catch (Exception Ex)
            {
                return BadRequest(string.Format("Erro ao logar + {0}", Ex.Message));
            }
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromHeader] string token ,[FromBody] Vendedor vendedor)
        {
            Vendedor vendedor1 = _service.Autorizado(token);
            if (vendedor1 == null)
            {
                return Unauthorized();
            }

            try
            {
                if (vendedor != null && vendedor.Id > 0)
                {
                    _vendedorRepository.Remover(vendedor);
                    return Ok();
                }

                return NotFound("Vendedor não deletado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromHeader] string token, [FromBody] Vendedor vendedor)
        {

            Vendedor vendedor1 = _service.Autorizado(token);
            if (vendedor1 == null)
            {
                return Unauthorized();
            }

            try
            {
                if (vendedor != null && vendedor.Id > 0)
                {
                    vendedor.DataAlteracao = DateTime.Now;
                    vendedor.UsuarioAlteracao = vendedor.Id;
                    vendedor = _vendedorRepository.Atualizar(vendedor);
                    return vendedor;
                }

                return NotFound("Vendedor não atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromHeader] string token, [FromBody] Vendedor vendedor)
        {
            Vendedor vendedor1 = _service.Autorizado(token);
            if (vendedor1 == null)
            {
                return Unauthorized();
            }

            try
            {
                if (vendedor != null)
                {
                    vendedor.DataAlteracao = DateTime.Now;
                    vendedor.UsuarioAlteracao = vendedor.Id;
                    vendedor.DataCriacao = DateTime.Now;
                    vendedor.UsuarioCriacao = vendedor.UsuarioAlteracao;

                    vendedor = _vendedorRepository.Adicionar(vendedor);
                    if (vendedor.Id > 0)
                    {
                        return vendedor;
                    }
                }

                return NotFound("Vendedor não Inserido!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<dynamic> Get([FromHeader] string token, int Id)
        {
            Vendedor vendedor1 = _service.Autorizado(token);
            if (vendedor1 == null)
            {
                return Unauthorized();
            }

            try
            {
                if (Id > 0)
                {
                    var vendedor = _vendedorRepository.ObterPorId(Id);
                    if (vendedor != null)
                    {
                        return vendedor;
                    }
                }

                return NotFound("Vendedor não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }

        [HttpGet]
        public object Get([FromHeader] string token)
        {
            Vendedor vendedor1 = _service.Autorizado(token);
            if (vendedor1 == null)
            {
                return Unauthorized();
            }

            try
            {
                var vendedor = _vendedorRepository.ObterTodos();
                if (vendedor != null)
                {
                    return vendedor;
                }

                return NotFound("Vendedor não existe!");
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro na chamada{0}", e.Message));
            }
        }
    }
}
