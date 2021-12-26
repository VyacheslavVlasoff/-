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
    public class WarehouseLineRepository : IRepository<WAREHOUSE_LINE>
    {
        private Model db;

        public WarehouseLineRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<WAREHOUSE_LINE> GetList()
        {
            return db.WAREHOUSE_LINE.ToList();
        }

        public WAREHOUSE_LINE GetItem(int id)
        {
            return db.WAREHOUSE_LINE.Find(id);
        }

        public void Create(WAREHOUSE_LINE item)
        {
            db.WAREHOUSE_LINE.Add(item);
        }

        public void Update(WAREHOUSE_LINE item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            WAREHOUSE_LINE item = db.WAREHOUSE_LINE.Find(id);
            if (item != null)
                db.WAREHOUSE_LINE.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
