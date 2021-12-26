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
    public class CommondityTypeRepository : IRepository<COMMONDITY_TYPE_REF>
    {
        private Model db;

        public CommondityTypeRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<COMMONDITY_TYPE_REF> GetList()
        {
            return db.COMMONDITY_TYPE_REF.ToList();
        }

        public COMMONDITY_TYPE_REF GetItem(int id)
        {
            return db.COMMONDITY_TYPE_REF.Find(id);
        }

        public void Create(COMMONDITY_TYPE_REF item)
        {
            db.COMMONDITY_TYPE_REF.Add(item);
        }

        public void Update(COMMONDITY_TYPE_REF item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            COMMONDITY_TYPE_REF item = db.COMMONDITY_TYPE_REF.Find(id);
            if (item != null)
                db.COMMONDITY_TYPE_REF.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

    }
}
