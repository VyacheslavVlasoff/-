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
    public class ProviderSupplyStockRepository: IRepository<PROVIDER_SUPPLY_STOCK>
    {
        private Model db;

        public ProviderSupplyStockRepository(Model dbcontext)
        {
            this.db = dbcontext;
        }

        public List<PROVIDER_SUPPLY_STOCK> GetList()
        {
            return db.PROVIDER_SUPPLY_STOCK.ToList();
        }

        public PROVIDER_SUPPLY_STOCK GetItem(int id)
        {
            return db.PROVIDER_SUPPLY_STOCK.Find(id);
        }

        public void Create(PROVIDER_SUPPLY_STOCK PROVIDER_SUPPLY_STOCK)
        {
            db.PROVIDER_SUPPLY_STOCK.Add(PROVIDER_SUPPLY_STOCK);
        }

        public void Update(PROVIDER_SUPPLY_STOCK PROVIDER_SUPPLY_STOCK)
        {
            db.Entry(PROVIDER_SUPPLY_STOCK).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PROVIDER_SUPPLY_STOCK PROVIDER_SUPPLY_STOCK = db.PROVIDER_SUPPLY_STOCK.Find(id);
            if (PROVIDER_SUPPLY_STOCK != null)
                db.PROVIDER_SUPPLY_STOCK.Remove(PROVIDER_SUPPLY_STOCK);
        }


    }
}
