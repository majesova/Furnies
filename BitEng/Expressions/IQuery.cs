using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitEng.Expressions
{
    public interface IQuery<T> where T : class
    {
        Expression<Func<T, bool>> Action(params Expression<Func<T, bool>>[] filters);
    }
}
