using System;
using System.Collections.Generic;

namespace Entities.Contracts
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity ObterPorId(int Id);
        TEntity ObterPorNome(string nome);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity entity);
        void Remover(TEntity entity);
    }
}
