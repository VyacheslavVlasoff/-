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
    public class WarehouseRepository : IRepository<WAREHOUSE>
    {
        private Model db;

        public WarehouseRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<WAREHOUSE> GetList()
        {
            return db.WAREHOUSE.ToList();
        }

        public WAREHOUSE GetItem(int id)
        {
            return db.WAREHOUSE.Find(id);
        }

        public void Create(WAREHOUSE item)
        {
            db.WAREHOUSE.Add(item);
        }

        public void Update(WAREHOUSE item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            WAREHOUSE item = db.WAREHOUSE.Find(id);
            if (item != null)
                db.WAREHOUSE.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
