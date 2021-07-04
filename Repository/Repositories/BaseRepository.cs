using Entities.Contracts;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Embarque.Repositorio.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public TEntity Adicionar(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TEntity ObterPorId(int Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public TEntity ObterPorNome(string nome)
        {
            return _context.Set<TEntity>().FirstOrDefault(s => s.Nome.Equals(nome));
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            var remove = _context.Set<TEntity>().Find(entity.Id);
            if (remove!= null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
        }
    }
}