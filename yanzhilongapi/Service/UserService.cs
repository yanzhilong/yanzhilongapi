using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;
using yanzhilong.Repository;
using yanzhilong.Security;

namespace yanzhilong.Service
{
    public class UserService : IBaseService<User>
    {
        private readonly IRepository<User> repository = new MbRepository<User>();
        private readonly SaltedHash saltedHash = new SaltedHash();

        public UserLoginResult ValidateUser(string UserNameOrEmailOrPhoneNumber, string Password)
        {
            UserLoginResult ulr = new UserLoginResult();
            var user = this.GetEntry(new User { UserName = UserNameOrEmailOrPhoneNumber });
            if (user == null)
                user = this.GetEntry(new User { Email = UserNameOrEmailOrPhoneNumber });
            if (user == null)
                user = this.GetEntry(new User { PhoneNumber = UserNameOrEmailOrPhoneNumber });

            if (user == null)
            {
                ulr.UserLoginResultEnum = UserLoginResultEnum.UserNotExist;
                return ulr;
            }
                
            if (user.CannotLoginUntilDateUtc.HasValue && user.CannotLoginUntilDateUtc.Value > DateTime.Now)
            {
                ulr.UserLoginResultEnum = UserLoginResultEnum.LockedOut;
                return ulr;
            }

            if (!PasswordsMatch(user, Password))
            {
                if (user.LastFailedLoginDateUtc != null)
                {
                    //判断最后一次错误时间和现在的间隔
                    TimeSpan ts = DateTime.Now - user.LastFailedLoginDateUtc.Value;
                    if (ts.TotalSeconds > 5 * 60)
                    {
                        //重置计数器
                        user.FailedLoginAttempts = 1;
                        user.LastFailedLoginDateUtc = DateTime.Now;
                        this.UpdateEntry(user);
                        ulr.TryCount = 5 - user.FailedLoginAttempts;
                        ulr.UserLoginResultEnum = UserLoginResultEnum.WrongPassword;
                        return ulr;
                    }
                }

                //密码错误，最多重试5次,锁定时间五分钟
                user.FailedLoginAttempts++;
                //if (_customerSettings.FailedPasswordAllowedAttempts > 0 &&
                //    customer.FailedLoginAttempts >= _customerSettings.FailedPasswordAllowedAttempts)
                if (user.FailedLoginAttempts >= 5)
                {
                    //锁定
                    user.CannotLoginUntilDateUtc = DateTime.Now.AddMinutes(5);
                    user.LastFailedLoginDateUtc = DateTime.Now;
                    //重置计数器
                    user.FailedLoginAttempts = 0;
                    this.UpdateEntry(user);
                    ulr.UserLoginResultEnum = UserLoginResultEnum.LockedOut;
                    return ulr;
                }

                user.CannotLoginUntilDateUtc = null;
                user.LastFailedLoginDateUtc = DateTime.Now;
                this.UpdateEntry(user);
                ulr.TryCount = 5 - user.FailedLoginAttempts;
                ulr.UserLoginResultEnum = UserLoginResultEnum.WrongPassword;
                return ulr;
            }

            //更新登陆信息
            user.FailedLoginAttempts = 0;
            user.LastFailedLoginDateUtc = null;
            user.CannotLoginUntilDateUtc = null;
            user.LastLoginDateUtc = DateTime.Now;
            this.UpdateEntry(user);

            ulr.UserLoginResultEnum = UserLoginResultEnum.Successful;
            return ulr;
        }
        
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enteredPassword"></param>
        /// <returns></returns>
        protected bool PasswordsMatch(User user, string enteredPassword)
        {
            if (user == null || string.IsNullOrEmpty(enteredPassword))
                return false;

            if (saltedHash.VerifyHashString(enteredPassword, user.PasswordHash, user.Salt))
            {
                return true;
            }
            return false;
        }

        public void AddEntry(User entry)
        {
            repository.Insert("InsertUser", entry);
        }

        public void AddEntrys(IList<User> entrys)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntry(User entry)
        {
            repository.Delete("DeleteUser", entry );
        }

        public void DeleteEntrys(IList<User> entrys)
        {
            throw new NotImplementedException();
        }

        public int GetCount(User entry)
        {
            throw new NotImplementedException();
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public User GetEntry(User entry)
        {
            User user = repository.GetByCondition("SelectUserByCondition", entry);
            return user;
        }

        public User GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(User entry)
        {
            IList<User> users = repository.GetList("SelectUserByCondition", entry);
            return users;
        }

        public IEnumerable<User> GetEntrys(User entry, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(int skip, int take, User entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(User entry)
        {
            repository.Update("UpdateUser", entry);
        }

        public void UpdateEntrys(IList<User> entrys)
        {
            throw new NotImplementedException();
        }
    }
}