using DAL;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DBDataOperation
    {
        private Model db;
        public DBDataOperation()
        {
            db = new Model();
            db.COMMONDITY.Load();
        }

        public List<Commondity> GetAllCommondity()
        {
            return db.COMMONDITY.ToList().Select(i => new Commondity(i)).ToList();
        }

        public Commondity GetCommondity(int ID)
        {
            return new Commondity(db.COMMONDITY.Find(ID));
        }

        public void CreateCommondity(COMMONDITY c)
        {
            db.COMMONDITY.Add(new COMMONDITY()
            {
                NAME = c.NAME,
                COMMONDITY_TYPE = c.COMMONDITY_TYPE,
                SIZE = c.SIZE
            });
            Save();
        }

        public void DeleteCommondity(int id)
        {
            COMMONDITY c = db.COMMONDITY.Find(id);
            if (c != null)
            {
                db.COMMONDITY.Remove(c);
                Save();
            }
        }

        public List<CommondityType> GetAllCommondityType()
        {
            return db.COMMONDITY_TYPE_REF.ToList().Select(i => new CommondityType(i)).ToList();
        }

        public List<Supply> GetAllSupply()
        {
            return db.SUPPLY.ToList().Select(i => new Supply(i)).ToList();
        }

        public void DeleteSupply(int id)
        {
            SUPPLY s = db.SUPPLY.Find(id);
            if (s != null)
            {
                db.SUPPLY.Remove(s);
                Save();
            }
        }

        public List<Warehouse> GetAllWarehouse()
        {
            return db.WAREHOUSE.ToList().Select(i => new Warehouse(i)).ToList();
        }

        public List<WarehouseLine> GetAllWarehouseLine()
        {
            return db.WAREHOUSE_LINE.ToList().Select(i => new WarehouseLine(i)).ToList();
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;  
            return false;
        }
    }
}
