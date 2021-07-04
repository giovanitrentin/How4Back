using Entities.Contracts;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HowVI.Services
{
    public class Service : IService
    {
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IContatoClienteRepository _contatoClienteRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly ITipoContatoRepository _tipoContatoRepository;
        private readonly IVendedorRepository _vendedorRepository;

        public Service(
                IAtividadeRepository atividadeRepository,
                IClienteRepository clienteRepository,
                IContatoClienteRepository contatoClienteRepository,
                IEmpresaRepository empresaRepository,
                IEnderecoRepository enderecoRepository,
                IStatusRepository statusRepository,
                ITipoContatoRepository tipoContatoRepository,
                IVendedorRepository vendedorRepository
                )
        {
            _atividadeRepository = atividadeRepository;
            _clienteRepository = clienteRepository;
            _contatoClienteRepository = contatoClienteRepository;
            _empresaRepository = empresaRepository;
            _enderecoRepository = enderecoRepository;
            _statusRepository = statusRepository;
            _tipoContatoRepository = tipoContatoRepository;
            _vendedorRepository = vendedorRepository;
        }

        public int ObterUsuarioPorToken(string token)
        {
            var ret = _vendedorRepository.ObterTodos()?.FirstOrDefault(v => v.TokenAccess.Equals(token));
            if (ret != null)
            {
                return ret.Id;
            }
            else
            {
                return 0;
            }
        }

        //Validação de acesso por token simples, para uma aplicação real, deve se usar um identity server ou algo similar.
        public Vendedor Autorizado(string token)
        {
            List<Vendedor> lista = _vendedorRepository.ObterTodos().ToList();
            foreach (Vendedor item in lista)
            {
                if (item.TokenAccess != null)
                {
                    if (item.TokenAccess.Equals(token))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public void InicializaBanco()
        {
            //Inicializa Status
            _statusRepository.Adicionar(new Status()
            {
                Nome = "Em Andamento",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _statusRepository.Adicionar(new Status()
            {
                Nome = "Concluído",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _statusRepository.Adicionar(new Status()
            {
                Nome = "Atrasado",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            //Inicializa Tipo Contato
            _tipoContatoRepository.Adicionar(new TipoContato()
            {
                Nome = "Visita",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _tipoContatoRepository.Adicionar(new TipoContato()
            {
                Nome = "Telefone",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            //Inicializa Endereço
            _enderecoRepository.Adicionar(new Endereco()
            {
                Rua = "Rua Teste 1",
                Numero = "1",
                Complemento = "Apto 101",
                Cidade = "Balneário Camboriú",
                Estado = "SC",
                Pais = "Brasil",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _enderecoRepository.Adicionar(new Endereco()
            {
                Rua = "Rua Teste 2",
                Numero = "101",
                Complemento = "Apto 102",
                Cidade = "Itajaí",
                Estado = "SC",
                Pais = "Brasil",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _enderecoRepository.Adicionar(new Endereco()
            {
                Rua = "Rua Teste 3",
                Numero = "1",
                Complemento = "Apto 1",
                Cidade = "São Paulo",
                Estado = "SP",
                Pais = "Brasil",
                IsAtivo = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            //Inicializa Empresa
            _empresaRepository.Adicionar(new Empresa()
            {
                Nome = "Empresa Teste",
                RazaoSocial = "Teste HoW VI",
                CNPJ = "111.1111/0001-00",
                Telefone = "(47) 9 96699-1588",
                Email = "teste@teste.com.br",
                IsAtivo = true,
                IdEndereco = 1,
                WebSite = "www.teste.com.br",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            //Inicializa Vendedores/Usuarios
            _vendedorRepository.Adicionar(new Vendedor()
            {
                Nome = "Helio Lidoni",
                Login = "helio.lidoni",
                Senha = "123456",
                Nascimento = DateTime.Now.AddDays(180).AddYears(-21),
                CPF = "111.111.111-00",
                IdEmpresa = 1,
                IsAtivo = true,
                Email = "heliolidoni@teste.com",
                Telefone = "(47) 9 9966-6600",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _vendedorRepository.Adicionar(new Vendedor()
            {
                Nome = "Giovani Trentin",
                Login = "giovani.trentin",
                Senha = "123456",
                Nascimento = DateTime.Now.AddDays(180).AddYears(-21),
                CPF = "222.222.222-00",
                IdEmpresa = 1,
                IsAtivo = true,
                Email = "giovani.trentin@teste.com",
                Telefone = "(47) 9 9955-6666",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _vendedorRepository.Adicionar(new Vendedor()
            {
                Nome = "Vitor Brongel",
                Login = "vitao",
                Senha = "123456",
                Nascimento = DateTime.Now.AddDays(180).AddYears(-21),
                CPF = "666.666.666-00",
                IdEmpresa = 1,
                IsAtivo = false,
                Email = "vitao@teste.com",
                Telefone = "(47) 9 9988-6666",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            //Inicializa Clientes
            _clienteRepository.Adicionar(new Cliente()
            {
                Nome = "WEG",
                RazaoSocial = "Teste Cliente",
                TipoDocumento = 1,
                Documento = "000.0000/0001-01",
                WebSite = "www.clienteteste.com.br",
                IdEndereco = 2,
                IsAtivo = true,
                Email = "teste@clienteteste.com",
                Fundacao = DateTime.Now.AddYears(-5),
                Telefone = "Sem telefone",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            _clienteRepository.Adicionar(new Cliente()
            {
                Nome = "Herring",
                RazaoSocial = "Teste Cliente 2",
                TipoDocumento = 1,
                Documento = "000.0000/0002-01",
                WebSite = "www.clienteteste2.com.br",
                IdEndereco = 3,
                IsAtivo = true,
                Email = "teste@clienteteste2.com",
                Fundacao = DateTime.Now.AddYears(-5),
                Telefone = "Sem telefone",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });

            //Inicializa Atividades
            _atividadeRepository.Adicionar(new Atividade()
            {
                Nome = "Venda para WEG",
                DescricaoContato = "Este é um contato de testes do projeto do curso ADS da Univali",
                IdCliente = 1,
                IsAtivo = true,
                IdStatus = 2,
                IdVendedor = 1,
                DataContato = DateTime.Now,
                DataProximoContato = DateTime.Now,
                DataRetorno = DateTime.Now,
                IdTipoContato = 1,
                IsContatoFinalizado = true,
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                UsuarioAlteracao = 1,
                UsuarioCriacao = 1
            });
        }
    }


    public interface IService
    {
        public Vendedor Autorizado(string token);
        public void InicializaBanco();
    }
}
