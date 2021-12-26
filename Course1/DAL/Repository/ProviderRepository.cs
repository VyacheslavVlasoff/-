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
    public class ProviderRepository : IRepository<PROVIDER>
    {
        private Model db;

        public ProviderRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<PROVIDER> GetList()
        {
            return db.PROVIDER.ToList();
        }

        public PROVIDER GetItem(int id)
        {
            return db.PROVIDER.Find(id);
        }

        public void Create(PROVIDER PROVIDER)
        {
            db.PROVIDER.Add(PROVIDER);
        }

        public void Update(PROVIDER PROVIDER)
        {
            db.Entry(PROVIDER).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PROVIDER PROVIDER = db.PROVIDER.Find(id);
            if (PROVIDER != null)
                db.PROVIDER.Remove(PROVIDER);
        }


    }
}
