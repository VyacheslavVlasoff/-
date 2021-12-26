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
    public class SupplyLineRepository : IRepository<SUPPLY_LINE>
    {
        private Model db;

        public SupplyLineRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SUPPLY_LINE> GetList()
        {
            return db.SUPPLY_LINE.ToList();
        }

        public SUPPLY_LINE GetItem(int id)
        {
            return db.SUPPLY_LINE.Find(id);
        }

        public void Create(SUPPLY_LINE item)
        {
            db.SUPPLY_LINE.Add(item);
        }

        public void Update(SUPPLY_LINE item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SUPPLY_LINE item = db.SUPPLY_LINE.Find(id);
            if (item != null)
                db.SUPPLY_LINE.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
