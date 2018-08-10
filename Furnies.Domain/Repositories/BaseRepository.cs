using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BitEng.Expressions;
using System.Linq.Dynamic;
using System.Linq.Expressions;
namespace Furnies.Domain.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Contexto de datos
        /// </summary>
        protected FurniesContext _context;
        /// <summary>
        /// Set de datos
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;
        /// <summary>
        /// Constructor default
        /// </summary>
        protected BaseRepository()
        {
            _dbSet = _context.Set<TEntity>();
        }
        /// <summary>
        /// Constructor con contexto
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(FurniesContext context)
        {
            if (context != null)
            {
                _context = context;
            }
            else
            {
                _context = new FurniesContext();
            }

            _dbSet = _context.Set<TEntity>();
        }
        public object ObjectState { get; private set; }
        /// <summary>
        /// Recarga el estado de ua entidad
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void Reload(TEntity entity)
        {
            (_context as DbContext).Entry(entity).Reload();
        }
        /// <summary>
        /// Encuentra un objeto por su id
        /// </summary>
        /// <param name="keyValues">Identificador de la entidad</param>
        /// <returns></returns>
        public virtual TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
        /// <summary>
        /// Consulta todos los datos de una tabla, realiza la consulta
        /// </summary>
        /// <returns>Colección de objetos</returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        /// <summary>
        /// Inserta una entidad
        /// </summary>
        /// <param name="entity">Entidad que se va  insertar</param>
        public virtual void Insert(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Added;
            _dbSet.Add(entity);
        }
        /// <summary>
        /// Marca una entidad como actualizada
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        public virtual void Update(TEntity entity)
        {
            if (!_dbSet.Local.Any(e => e == entity))
                _dbSet.Attach(entity);

            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Inserta un conjunto de entidades
        /// </summary>
        /// <param name="entities">Colección de entidades</param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }
        /// <summary>
        /// Marca una entidad como eliminada
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            if (!_dbSet.Local.Any(e => e == entity))
                _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }
        /// <summary>
        /// Consulta que acepta una expresión, si no se desean filtros, pasar null
        /// </summary>
        /// <param name="where">Expresión, acepta null</param>
        /// <param name="includes">Arraeglo de inclusiones</param>
        /// <param name="order">Criterio de ordenamiento</param>
        /// <returns>Colección de objetos</returns>
        public virtual ICollection<TEntity> Query(Expression<Func<TEntity, bool>> where, string order = "")
        {
            var query = _dbSet.AsQueryable();
            if (where != null)
                query = query.Where(where);
            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);
            return query.ToList();
        }
        /// <summary>
        /// Consulta que acepta una expresión e includes, si no se desean filtros, pasar null
        /// </summary>
        /// <param name="where">Expresión, acepta null</param>
        /// <param name="includes">Arraeglo de inclusiones</param>
        /// <param name="order">Criterio de ordenamiento</param>
        /// <returns>Colección de objetos</returns>
        public virtual ICollection<TEntity> QueryIncluding(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>>[] includes, string order = "")
        {
            var query = _dbSet.AsQueryable();
            if (where != null)
                query = query.Where(where);

            if (includes.Length > 0)
            {
                foreach (var inc in includes)
                {
                    query = query.Include(inc);
                }
            }

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);
            return query.ToList();
        }
       
        public virtual ICollection<TEntity> QueryPage(Expression<Func<TEntity, bool>> where, out int totalPages, out int totalRows, string order, int page = 1, int pageSize = 10)
        {
            if (pageSize <= 0) throw new Exception("El valor del parámetro 'pageSize' debe ser mayor que cero");
            if (string.IsNullOrEmpty(order)) throw new Exception("Es necesario indicar un orden para una consulta paginada");
            if (page > 0) 
                page--;//Index 0..N
            var query = _dbSet.AsQueryable();
            if (where != null)
                query = query.Where(where);
            var totalCount = query.Count();
            totalRows = totalCount;
            query = query.OrderBy(order).Skip(pageSize * page).Take(pageSize);
            var results = query.AsNoTracking().ToList();
            totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return results;
        }
        /// <summary>
        /// Consulta paginada por un criterio en un expression, si no se requiere filtros pasar null el where
        /// </summary>
        /// <param name="where">Expresión con condiciones</param>
        /// <param name="includes">includes</param>
        /// <param name="totalPages">Páginas totales encontradas</param>
        /// <param name="totalRows">Número de filas encontradas</param>
        /// <param name="order">Criterio de ordenamiento</param>
        /// <param name="page">Página que se quiere consultar, inicia en </param>
        /// <param name="pageSize">Tamaño de página que se requier</param>
        /// <returns>Colección de objetos</returns>
        public virtual ICollection<TEntity> QueryPageIncluding(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>>[] includes, out int totalPages, out int totalRows, string order, int page = 1, int pageSize = 10)
        {
            if (pageSize <= 0) throw new Exception("El valor del parámetro 'pageSize' debe ser mayor que cero");
            if (string.IsNullOrEmpty(order)) throw new Exception("Es necesario indicar un orden para una consulta paginada");
            if (page > 0)
                page--;//Index 0..N
            var query = _dbSet.AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var inc in includes)
                {
                    query = query.Include(inc);
                }
            }
            if (where != null)
                query = query.Where(where);
            var totalCount = query.Count();
            totalRows = totalCount;
            query = query.OrderBy(order).Skip(pageSize * page).Take(pageSize); ;
            var results = query.AsNoTracking().ToList();
            totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return results;
        }
        
    }

}
