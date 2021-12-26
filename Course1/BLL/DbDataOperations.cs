using DAL;
using BLL.Models;
using BLL.Services;
using BLL.Interfaces;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class DBDataOperation : IDbCrud
    {
        IDbRepos db;
        public DBDataOperation(IDbRepos repos)
        {
            db = repos;
        }

        #region Commondity
        public List<Commondity> GetAllCommondity()
        {
            return db.COMMONDITY.GetList().Select(i => new Commondity(i)).ToList();
        }

        public Commondity GetCommondity(int ID)
        {
            return new Commondity(db.COMMONDITY.GetItem(ID));
        }

        public void UpdateCommondity(Commondity c)
        {
                COMMONDITY co = db.COMMONDITY.GetItem(c.Id);
                co.NAME = c.Name;
                co.COMMONDITY_TYPE = c.CommondityType;
                co.SIZE = c.Size;
                Save();
        }

        public void CreateCommondity(List<SupplyService.CreateSupplyData> c)
        {
            c.Where(i => i.check == true && i.CommonId == db.COMMONDITY.GetItem(i.CommonId).ID).Select(i => new COMMONDITY
            {
                NAME = i.Name,
                SIZE = i.Size,
                COMMONDITY_TYPE = i.TypeId
            }).ToList();
            Save();
        }

        public void CreateCommondity(Commondity c)
        {
            db.COMMONDITY.Create(new COMMONDITY()
            {
                NAME = c.Name,
                COMMONDITY_TYPE = c.CommondityType,
                SIZE = c.Size
            });
            Save();
        }

        public void DeleteCommondity(int id)
        {
            COMMONDITY c = db.COMMONDITY.GetItem(id);
            if (c != null)
            {
                db.COMMONDITY.Delete(c.ID);
                Save();
            }
        }
        #endregion

        #region CommondityType
        public List<CommondityType> GetAllCommondityType()
        {
            return db.COMMONDITY_TYPE_REF.GetList().Select(i => new CommondityType(i)).ToList();
        }
        #endregion

        #region Supply
        public List<Supply> GetAllSupply()
        {
            return db.SUPPLY.GetList().Select(i => new Supply(i)).ToList();
        }

        public Supply GetSupply(int ID)
        {
            return new Supply(db.SUPPLY.GetItem(ID));
        }

        public void UpdateSupply(Supply c)
        {
            SUPPLY co = db.SUPPLY.GetItem(c.Id);
            co.COST = c.Cost;
            co.APPLICATION_DATE = c.ApplicationDate;
            co.DELIVERY_DATE = c.DeliveryDate;
            co.STATUS_ID = c.Status;
            Save();
        }

        public void DeleteSupply(int id)
        {
            SUPPLY s = db.SUPPLY.GetItem(id);
            if (s != null)
            {
                db.SUPPLY.Delete(s.ID);
                Save();
            }
        }
        #endregion

        #region SupplyLine
        public SupplyLine GetSupplyLine(int ID)
        {
            return null;
        }

        public void CreateSupplyLine(List<SupplyService.CreateSupplyData> c, SUPPLY s)
        {
            c.Where(i => i.check == true).Select(i => new SUPPLY_LINE
            {
                SUPPLY_ID = s.ID,
                COMMONDITY_ID = i.CommonId,
                QUANTITY = i.Quantity,
                COST = i.Cost
            }).ToList();
            Save();
        }

        public void DeleteSupplyLine(int IdSup)
        {
            SUPPLY_LINE sup = new SUPPLY_LINE();
            var sl = db.SUPPLY_LINE.GetList().Where(i => i.SUPPLY_ID == IdSup).Select(i => i.ID).ToList();
            Save();
        }

        public List<SupplyLine> GetAllSupplyLines()
        {
            return db.SUPPLY_LINE.GetList().Select(i => new SupplyLine(i)).ToList();
        }
        #endregion

        #region Warehouse
        public List<Warehouse> GetAllWarehouse()
        {
            return db.WAREHOUSE.GetList().Select(i => new Warehouse(i)).ToList();
        }
        #endregion

        #region WarehouseLine
        public List<WarehouseLine> GetAllWarehouseLine()
        {
            return db.WAREHOUSE_LINE.GetList().Select(i => new WarehouseLine(i)).ToList();
        }

        public WarehouseLine GetWarehouseLine(int ID)
        {
            return new WarehouseLine(db.WAREHOUSE_LINE.GetItem(ID));
        }

        public void CreateWarehouseLine(List<SupplyService.CreateSupplyData> c)
        {
            c.Where(i => i.check == true && db.WAREHOUSE_LINE.GetItem(i.CommonId) == null).Select(i => new WAREHOUSE_LINE
            {
                COMMONDITY_ID = i.CommonId,
                WAREHOUSE_ID = 1,
                PER_UNIT_COST = i.Cost,
                QUANTITY = i.Quantity
            }).ToList();
            Save();
        }

        public void UpdateWarehouseLine(List<SupplyService.CreateSupplyData> c)
        {
            c.Where(i => i.CommonId == db.WAREHOUSE_LINE.GetItem(i.CommonId).ID)
                .Select(i => db.WAREHOUSE_LINE.GetItem(i.CommonId).QUANTITY += i.Quantity)
                .ToList();
            Save();
        }
        #endregion

        #region Providers
        public List<Providers> GetAllProviders()
        {
            return db.PROVIDER.GetList().Select(i => new Providers(i)).ToList();
        }
        #endregion

        #region Status
        public List<Status> GetAllStatus()
        {
            return db.SUPPLY_STATUS_REF.GetList().Select(i => new Status(i)).ToList();
        }
        #endregion

        public bool Save()
        {
            if (db.Save() > 0) return true;  
            return false;
        }
    }
}
