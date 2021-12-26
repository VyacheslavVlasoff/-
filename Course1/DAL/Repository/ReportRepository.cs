using System;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class ReportRepository : ISupplyRepository
    {
        private Model db;

        public ReportRepository(Model dbcontext)
        {
            db = dbcontext;
        }

        public List<CreateSupplyData> WarehouseCheck(int idProv)
        {
            Model db = new Model();

            var request = db.WAREHOUSE_LINE
                .Join(db.PROVIDER_SUPPLY_STOCK, i => i.COMMONDITY_ID, j => j.COMMONDITY_ID, (i, j) => new { i, j })
                .Where(i => i.j.PROVIDER_ID == idProv)
          .Select(i => new CreateSupplyData()
          {
              Id = i.i.ID,
              Name = i.i.COMMONDITY.NAME,
              CommonId = i.i.COMMONDITY_ID,
              Type = i.i.COMMONDITY.COMMONDITY_TYPE_REF.TYPE,
              TypeId = i.j.COMMONDITY_ID,
              Size = i.i.COMMONDITY.SIZE,
              ProviderId = i.j.PROVIDER_ID,
              Provider = i.j.PROVIDER.FAMILY_NAME,
              Cost = i.i.PER_UNIT_COST,
              check = false,
              Quantity = i.i.QUANTITY

          })
          .ToList();
            return request;
        }

        public bool MakeSupply(List<CreateSupplyData> csd)
        {
            decimal sum = 0;

            csd.Where(l => l.check == true).Select(l => sum += l.Cost * l.Quantity).ToList();

            SUPPLY s = new SUPPLY
            {
                COST = sum,
                APPLICATION_DATE = DateTime.Now,
                //PROVIDER_ID = Convert.ToInt32(csd.Select(l => l.ProviderId).ToList()),
                STATUS_ID = 2,
                WAREHOUSE_ID = 1,
                APPLICANT_ID = 1,
            };
            csd.Select(l => s.PROVIDER_ID = l.ProviderId).ToList();
            db.SUPPLY.Add(s);

            csd.Where(l => l.check == true && db.COMMONDITY.Find(l.CommonId) == null)
                .Select(l => db.COMMONDITY.Add(new COMMONDITY
                {
                    NAME = l.Name,
                    COMMONDITY_TYPE = l.TypeId,
                    SIZE = l.Size
                }));

            // dbcontext.CreateCommondity(csd);

            csd.Where(l => l.check == true).Select(l => db.SUPPLY_LINE.Add(new SUPPLY_LINE
            {
                SUPPLY_ID = s.ID,
                COMMONDITY_ID = l.CommonId,
                QUANTITY = l.Quantity,
                COST = l.Cost
            })).ToList();

            //dbcontext.CreateSupplyLine(csd, s);

            csd.Where(l => l.check == true && db.WAREHOUSE_LINE.Find(l.CommonId) == null)
                .Select(l => db.WAREHOUSE_LINE.Add(new WAREHOUSE_LINE
            {
                COMMONDITY_ID = l.CommonId,
                WAREHOUSE_ID = 1,
                PER_UNIT_COST = l.Cost,
                QUANTITY = l.Quantity
            })).ToList();

            csd.Where(i => i.CommonId == db.WAREHOUSE_LINE.Find(i.CommonId).ID)
               .Select(i => db.WAREHOUSE_LINE.Find(i.CommonId).QUANTITY += i.Quantity)
               .ToList();
            //dbcontext.CreateWarehouseLine(csd);
            //dbcontext.UpdateWarehouseLine(csd);

            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<CreateWarehouse> createWarehouseLine()
        {
            Model db = new Model();

            var request = db.WAREHOUSE_LINE
                .Join(db.PROVIDER_SUPPLY_STOCK, i => i.COMMONDITY_ID, j => j.COMMONDITY_ID, (i, j) => new { i, j })
          .Select(i => new CreateWarehouse()
          {
              Id = i.i.ID,
              Name = i.i.COMMONDITY.NAME,
              Addres = i.i.WAREHOUSE.ADDRESS,
              Cost = i.j.COST,
              Count = i.i.QUANTITY
          })
          .ToList();
            return request;
        }
    }
}
