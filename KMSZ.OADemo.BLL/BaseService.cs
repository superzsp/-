using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.BLL
{
    public abstract class BaseService<T> where T :class, new()
    {
        //public IDAL.IDbSession DbSession = DalFactory.DbSessionFactory.GetCurrentDbSession();
        public IDAL.IDbSession DbSession
        {
            get
            {
                return DalFactory.DbSessionFactory.GetCurrentDbSession();
            }
        } 
        public IDAL.IBaseDal<T> CurrentDal;//依赖抽象的接口
        public int Savechanges()
        {
            return DbSession.saveChanges();
        }
        //要求所有业务方法在执行前必须给当前CurrentDal赋值
        public BaseService()
        {
            //执行给当前CurrentDal赋值
            //强迫子类给当前类的CurrentDal赋值
            SetCurrentDal();//调用了一个abstract抽象方法
        }
        //子类必须重写此方法
        public abstract void SetCurrentDal();
        public virtual T Add(T entity)
        {
            //目的要拿到T对应的Dal
            return CurrentDal.Add(entity);
        }

        public virtual int Delete(params int[] ids)
        {
            return CurrentDal.Delete(ids);
        }
        public virtual bool Delete(T entity)
        {
            return CurrentDal.Delete(entity);//db.SaveChanges() > 0;
        }

        public IQueryable<T> LoadTs(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadTs(whereLambda);

        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        ///  int total=0;
        /// this.LoadTs<int>(5, 1, out total, u => true, s => s.Id, true);
        public IQueryable<T> LoadTs<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadTs(pageSize, pageIndex, out total, whereLambda, orderbyLambda, isAsc);
        }
        public bool Update(T entity)
        {
            return CurrentDal.Update(entity);
        }
    }
}
