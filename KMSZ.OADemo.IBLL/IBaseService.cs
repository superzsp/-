using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IBLL
{
    public interface IBaseService<T> where T :class,new()
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        int Delete(params int[] ids);

        //u=>true查询所有数据
        IQueryable<T> LoadTs(Expression<Func<T, bool>> whereLambda);//规约设计模式，where a>10
        IQueryable<T> LoadTs<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc);
        int Savechanges();
    }
}
