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
    public class SupplyRepository : IRepository<SUPPLY>
    {
        private Model db;

        public SupplyRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SUPPLY> GetList()
        {
            return db.SUPPLY.ToList();
        }

        public SUPPLY GetItem(int id)
        {
            return db.SUPPLY.Find(id);
        }

        public void Create(SUPPLY SUPPLY)
        {
            db.SUPPLY.Add(SUPPLY);
        }

        public void Update(SUPPLY SUPPLY)
        {
            db.Entry(SUPPLY).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SUPPLY SUPPLY = db.SUPPLY.Find(id);
            if (SUPPLY != null)
                db.SUPPLY.Remove(SUPPLY);
        }


    }
}
