using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private VanDoanhContext db;

        public UserDao()
        {
            db = new VanDoanhContext();
        }
        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.PassWord.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public string Insert(UserAccount entityUser)
        {
            var user = Find(entityUser.UserName);
            if (user == null)
            {
                db.UserAccounts.Add(entityUser);
            }
            else
            {
                user.UserName = entityUser.UserName;
                if (!String.IsNullOrEmpty(entityUser.PassWord))
                {
                    user.PassWord = entityUser.PassWord;
                }
            }
            db.SaveChanges();
            return entityUser.UserName;
        }


        public bool Delete(string username)
        {
            try
            {
                var user = db.UserAccounts.Find(username);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserAccount Find(string username)
        {
            return db.UserAccounts.Find(username);
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
