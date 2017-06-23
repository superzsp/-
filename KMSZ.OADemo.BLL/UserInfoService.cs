using KMSZ.OADemo.DAL;
using KMSZ.OADemo.DalFactory;
using KMSZ.OADemo.IBLL;
using KMSZ.OADemo.IDAL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.BLL
{
    public partial class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
        private string _Name = DateTime.Now.ToString();
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }
        #region 批量删除
        /// <summary>
        /// 添加一个方法来删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteIds(params int[] ids)
        {
            foreach (var id in ids)
            {
                var user=DbSession.UserInfoDal.LoadTs(u => u.Id == id).FirstOrDefault();
                user.DelFlag = (short)Model.Enum.DelFlagEnum.Deleted;
            }
            return DbSession.saveChanges();
        }
        #endregion
        /*
        //private DAL.UserInfoEFDal _UserInfoEfDal = new DAL.UserInfoEFDal();

        //有可能用EF实现DAL层，也有可能用ADONET实现DAL层，而且有可能不同数据库,sql,oracle,mysql
        //通过让BLL去依赖一个公共的不怎么变化的契约借口，依赖抽象的东西，具体的实现变化时BLL层不需要变化
        //IDAL.IUserInfoDal userInfoDal = DalFactory.DalSimpleFactory.GetUserInfoDal();
        //new UserInfoEFDal（）实例的创建，在很多的services中都有我们希望改一个地方，所有创建实例的地方都能改变
        //1、对变化点进行封装
        //2、依赖抽象的基类，接口等进行编程
        //DalFactory.DbSession dbSession = new DalFactory.DbSession();
        //使用简单工厂

        //保证DbSession线程内实例唯一
        private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
        //使用抽象工厂
        //IOC依赖注入，Spring.Net 
        //java: SSH struct2=aspnet mvc spring=spring.Net hibernate=Nhibernate,EF
        public UserInfo AddUserInfo(UserInfo userInfo)
        {
            //用户注册场景
            //用户注册完成后，添加一个角色
            dbSession.RoleDal.Add(new Role());
            dbSession.RoleDal.Add(new Role());
            dbSession.RoleDal.Add(new Role());
            dbSession.saveChanges();
            dbSession.RoleDal.Update(new Role());
            dbSession.saveChanges();
            return dbSession.UserInfoDal.Add(userInfo);
        }*/
        /*public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        }*/
        #region 搜索查询
        public IQueryable<UserInfo> LoadSearchData(SearchUserParam param)
        {
            //首先第一步先进行过滤
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            var temp = DbSession.UserInfoDal.LoadTs(u => u.DelFlag == delNormal);
            //进行用户名搜索的过滤
            if (!string.IsNullOrEmpty(param.SName))
            {
                temp = temp.Where(u => u.UserName.Contains(param.SName));
            }
            //进行邮箱的过滤
            if (!string.IsNullOrEmpty(param.SMail))
            {
                temp = temp.Where(u => u.Mail.Contains(param.SMail));
            }
            //设置总条数
            param.Total = temp.Count();
            //分页的处理
            return temp.OrderBy(u => u.Id).Skip(param.PageSize * (param.PageIndex - 1)).Take(param.PageSize).AsQueryable();
        }
        #endregion
        #region 设置用户角色
        public bool SetUserRole(int userId, List<int> roleIds)
        {
            var user = DbSession.UserInfoDal.LoadTs(u => u.Id == userId).FirstOrDefault();
            user.Role.Clear();
            foreach (var roleId in roleIds)
            {
                var role = DbSession.RoleDal.LoadTs(r => r.Id == roleId).FirstOrDefault();
                user.Role.Add(role);
            }
            this.Savechanges();
            return true;
        }
        #endregion
    }
}
