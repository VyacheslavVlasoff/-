using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IRepository<USER>
    {
        private Model db;

        public UserRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<USER> GetList()
        {
            return db.USER.ToList();
        }

        public USER GetItem(int id)
        {
            return db.USER.Find(id);
        }

        public void Create(USER item)
        {
            db.USER.Add(item);
        }

        public void Update(USER item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            USER item = db.USER.Find(id);
            if (item != null)
                db.USER.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
