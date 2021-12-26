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
    public class CommondityRepository : IRepository<COMMONDITY>
    {
        private Model db;

        public CommondityRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<COMMONDITY> GetList()
        {
            return db.COMMONDITY.ToList();
        }

        public COMMONDITY GetItem(int id)
        {
            return db.COMMONDITY.Find(id);
        }

        public void Create(COMMONDITY common)
        {
            db.COMMONDITY.Add(common);
        }

        public void Update(COMMONDITY common)
        {
            db.Entry(common).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            COMMONDITY common = db.COMMONDITY.Find(id);
            if (common != null)
                db.COMMONDITY.Remove(common);
        }


    }
}
