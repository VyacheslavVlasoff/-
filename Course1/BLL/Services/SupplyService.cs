using DAL;
using DAL.Interfaces;
using BLL.Models;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public partial class SupplyService : ISupplyService
    {
        private IDbRepos db;
        public SupplyService(IDbRepos repos)
        {
            db = repos;
        }

        public class CreateSupplyData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CommonId { get; set; }
            public string Type { get; set; }
            public int TypeId { get; set; }
            public int? Size { get; set; }
            public string Provider { get; set; }
            public decimal Cost { get; set; }
            public bool check { get; set; }
            public int Quantity { get; set; }

            public int ProviderId { get; set; }
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
            DBDataOperation dbcontext = new DBDataOperation(db);
            decimal sum = 0;

            csd.Where(l => l.check == true).Select(l => sum += l.Cost*l.Quantity).ToList();

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
            db.SUPPLY.Create(s);

            //csd.Where(l => l.check == true && db.COMMONDITY.GetItem(l.CommonId) == null)
            //    .Select(l => db.COMMONDITY.Create(new COMMONDITY
            //{
            //    NAME = l.Name,
            //    COMMONDITY_TYPE = l.TypeId,
            //    SIZE = l.Size
            //}));

            dbcontext.CreateCommondity(csd);

            //csd.Where(l => l.check == true).Select(l => db.SUPPLY_LINE.Create(new SUPPLY_LINE
            //{
            //    SUPPLY_ID = s.ID,
            //    COMMONDITY_ID = l.CommonId,
            //    QUANTITY = l.Quantity,
            //    COST = l.Cost
            //})).ToList();

            dbcontext.CreateSupplyLine(csd, s);

            //csd.Where(l => l.check == true && db.WAREHOUSE_LINE.GetItem(l.CommonId) == null).Select(l => db.WAREHOUSE_LINE.Create(new WAREHOUSE_LINE
            //{
            //    COMMONDITY_ID = l.CommonId,
            //    WAREHOUSE_ID = 1,
            //    PER_UNIT_COST = l.Cost,
            //    QUANTITY = l.Quantity
            //})).ToList();

            dbcontext.CreateWarehouseLine(csd);
            dbcontext.UpdateWarehouseLine(csd);

            if (db.Save() > 0)
            {
                return true;
            }
            return false;
        }

        public class CreateWarehouse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Addres { get; set; }
            public decimal Cost { get; set; }
            public int Count { get; set; }
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

        //public class SupplyStatus
        //{
        //    public int Id { get; set; }
        //    public decimal Cost { get; set; }
        //    public DateTime ApplicationDate { get; set; }
        //    public DateTime? DeliveryDate { get; set; }
        //    public int StatusId { get; set; }
        //}

        //public static List<SupplyStatus> SupplyList()
        //{
        //    Model db = new Model();

        //    var request = db.SUPPLY
        //       .Select(i => new SupplyStatus()
        //  {
        //      Id = i.ID,
        //      Cost = i.COST,
        //      ApplicationDate = i.APPLICATION_DATE,
        //      DeliveryDate = i.DELIVERY_DATE,
        //      StatusId = i.SUPPLY_STATUS_REF.ID
        //  })
        //  .ToList();
        //    return request;
        //}
    }
}
