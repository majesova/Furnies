using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furnies.Application
{
    public interface IQueryObject<TEntity>
    {
        /// <summary>
        /// Construye una expresión
        /// </summary>
        /// <returns>Expression</returns>
        Expression<Func<TEntity, bool>> Query();
        /// <summary>
        /// Sentencia AND en una expresión
        /// </summary>
        /// <param name="query">Consulta a incluir como AND</param>
        /// <returns>Expression</returns>
        Expression<Func<TEntity, bool>> And(Expression<Func<TEntity, bool>> query);
        /// <summary>
        /// Sentencia OR en una expresión
        /// </summary>
        /// <param name="query">Query para agregar como OR</param>
        /// <returns>Expression</returns>
        Expression<Func<TEntity, bool>> Or(Expression<Func<TEntity, bool>> query);
        /// <summary>
        /// Sentencia AND a partir de otro objeto QueryObject
        /// </summary>
        /// <param name="queryObject">Objeto QueryObject con una consulta armada</param>
        /// <returns>Expression</returns>
        Expression<Func<TEntity, bool>> And(IQueryObject<TEntity> queryObject);
        /// <summary>
        /// Sentencia OR a partir de otro objeto QueryObject
        /// </summary>
        /// <param name="queryObject">Object QueryObject con una consulta armada</param>
        /// <returns>Expression</returns>
        Expression<Func<TEntity, bool>> Or(IQueryObject<TEntity> queryObject);
    }
}
