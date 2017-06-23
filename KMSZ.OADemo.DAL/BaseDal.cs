using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.DAL
{
    public class BaseDal<T> where T :class,new()
    {
        //上下文不能直接new,要保证线程内的实例唯一
        //考虑思路：当前类的职责是什么？当前的需求和当前类的职责是否一致
        //Model.DataModelContainer db = new DataModelContainer();
      // private DbContext db =EFDbContextFactory.GetCurrentDbContext();
        private DbContext db
        {
            get
            {
                return EFDbContextFactory.GetCurrentDbContext();
            }
        }
        public virtual T Add(T entity)
        {
            db.Set<T>().Add(entity);
            //db.SaveChanges();
            return entity;
        }

        public virtual int Delete(params int[] ids)
        {
            foreach (var item in ids)
            {
                //首先可以通过泛型的基类的约束来实现对id字段赋值
                var entity = db.Set<T>().Find(item);//如果实体已经存在内存中，就直接从内存中拿，如果内存中没有，那么查询数据库
                db.Set<T>().Remove(entity);
            }
            return ids.Count();//db.SaveChanges();
        }
        public virtual bool Delete(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return true;//db.SaveChanges() > 0;
        }

        public IQueryable<T> LoadTs(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).AsQueryable();

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
        public IQueryable<T> LoadTs<S>(int pageSize, int pageIndex, out int total,Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            total = db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                return db.Set<T>().Where(whereLambda).OrderBy(orderbyLambda)
                 .Skip(pageSize * (pageIndex - 1))
                 .Take(pageSize).AsQueryable();
            }
            else
            {
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderbyLambda)
                 .Skip(pageSize * (pageIndex - 1))
                 .Take(pageSize).AsQueryable();
            }
        }
        public bool Update(T entity)
        {
            //db.Set<T>().Attach(entity);
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return true;// db.SaveChanges() > 0;
        }
    }
}
