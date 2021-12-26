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
    public class SupplyStatusRefRepository : IRepository<SUPPLY_STATUS_REF>
    {
        private Model db;

        public SupplyStatusRefRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SUPPLY_STATUS_REF> GetList()
        {
            return db.SUPPLY_STATUS_REF.ToList();
        }

        public SUPPLY_STATUS_REF GetItem(int id)
        {
            return db.SUPPLY_STATUS_REF.Find(id);
        }

        public void Create(SUPPLY_STATUS_REF item)
        {
            db.SUPPLY_STATUS_REF.Add(item);
        }

        public void Update(SUPPLY_STATUS_REF item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SUPPLY_STATUS_REF item = db.SUPPLY_STATUS_REF.Find(id);
            if (item != null)
                db.SUPPLY_STATUS_REF.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
