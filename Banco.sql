
use SistemaGerenciamentoCliente

alter table Cliente drop constraint FkEnderecoCliente
alter table ContatoCliente drop constraint FkClienteContatoCliente
alter table Empresa drop constraint FkEnderecoEmpresa
alter table Vendedor drop constraint FkEmpresa
alter table Atividade drop constraint FkCliente
alter table Atividade drop constraint FkContatoCliente
alter table Atividade drop constraint FkVendedor
alter table Atividade drop constraint FkStatus
alter table Atividade drop constraint FkTipoContato

drop table Cliente
drop table ContatoCliente
drop table Endereco
drop table TipoContato
drop table Status
drop table Atividade
drop table Empresa
drop table Vendedor

CREATE TABLE Cliente (
    Id int not null primary key identity(1,1),
    RazaoSocial varchar(255) not null, 
	Nome varchar(255) not null, 
    TipoDocumento int not null, 
    Documento varchar(50) not null, 
    IdEndereco int not null, 
    Telefone varchar(25) null,
    WebSite varchar(50) null,
    Email varchar(50) null,
    Fundacao date null,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)

CREATE TABLE ContatoCliente (
    Id int not null primary key identity(1,1),
    IdCliente int not null, 
    Nome varchar(255) not null,
    Telefone varchar(25) null,
    Celular varchar(25) null,
    Email varchar(250) null,
    Aniversario date null,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)

CREATE TABLE Endereco (
    Id int not null primary key identity(1,1),
    Rua varchar(255) not null,
    Numero varchar(8) not null,
    Complemento varchar(255) null,
    Cidade varchar(255) not null,
    Estado varchar(255) not null,
    Pais varchar(255) not null,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)

CREATE TABLE TipoContato (
    Id int not null primary key identity(1,1),
    Nome varchar(255) not null,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)

CREATE TABLE Status (
    Id int not null primary key identity(1,1),
    Nome varchar(255) not null,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)

CREATE TABLE Atividade (
    Id int not null primary key identity(1,1),
	Nome varchar(255) not null,
    IdCliente int not null, 
    IdContatoCliente int null, 
    IdVendedor int not null, 
    IdStatus int not null, 
    IdTipoContato int not null, 
    DataContato datetime not null, 
    DescricaoContato varchar(max) not null, 
    DataRetorno datetime null, 
    DataProximoContato datetime null, 
    IsContatoFinalizado bit not null default 0,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)

CREATE TABLE Empresa (
    Id int not null primary key identity(1,1),
    RazaoSocial varchar(255) not null,
    Nome varchar(255) not null,
    IdEndereco int not null, 
    CNPJ varchar(25) not null, 
    Telefone varchar(25) null,
    WebSite varchar(50) null, 
    Email varchar(250),
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null
)
    
    
CREATE TABLE Vendedor (
    Id int not null primary key identity(1,1),
    IdEmpresa int not null, 
    Nome varchar(255) not null,
	Login varchar(255) null,
	Senha varchar(255) null,
    Nascimento Date null, 
    CPF varchar(20) not null,
    Telefone varchar(25) null,
    Email varchar(250) not null,
    IsAtivo bit not null default 1,
	DataCriacao datetime not null,
	DataAlteracao datetime not null,
	UsuarioCriacao int not null,
	UsuarioAlteracao int not null,
	TokenAccess varchar(200) null
)

ALTER TABLE Cliente 
    ADD CONSTRAINT FkEnderecoCliente 
    FOREIGN KEY (IdEndereco)
    REFERENCES Endereco(Id);

ALTER TABLE ContatoCliente 
    ADD CONSTRAINT FkClienteContatoCliente 
    FOREIGN KEY (IdCliente)
    REFERENCES Cliente(Id);

ALTER TABLE Empresa 
    ADD CONSTRAINT FkEnderecoEmpresa 
    FOREIGN KEY (IdEndereco)
    REFERENCES Endereco(Id);        

ALTER TABLE Vendedor 
    ADD CONSTRAINT FkEmpresa 
    FOREIGN KEY (IdEmpresa)
    REFERENCES Empresa(Id);     

ALTER TABLE Atividade 
    ADD CONSTRAINT FkCliente 
    FOREIGN KEY (IdCliente)
    REFERENCES Cliente(Id);

ALTER TABLE Atividade 
    ADD CONSTRAINT FkContatoCliente 
    FOREIGN KEY (IdContatoCliente)
    REFERENCES ContatoCliente(Id);

ALTER TABLE Atividade 
    ADD CONSTRAINT FkVendedor 
    FOREIGN KEY (IdVendedor)
    REFERENCES Vendedor(Id);

ALTER TABLE Atividade 
    ADD CONSTRAINT FkStatus 
    FOREIGN KEY (IdStatus)
    REFERENCES Status(Id);

ALTER TABLE Atividade 
    ADD CONSTRAINT FkTipoContato 
    FOREIGN KEY (IdTipoContato)
    REFERENCES TipoContato(Id);
