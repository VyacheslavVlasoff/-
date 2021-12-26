using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private Model db;
        private CommondityRepository commondityRepository;
        private CommondityTypeRepository commondityTypeRepository;
        private ProviderRepository providerRepository;
        private ProviderSupplyStockRepository providerSupplyRepository;
        private SupplyLineRepository supplyLineRepository;
        private SupplyRepository supplyRepository;
        private SupplyStatusRefRepository supplyStatusRefRepository;
        private UserRepository userRepository;
        private WarehouseRepository warehouseRepository;
        private WarehouseLineRepository warehouseLineRepository;
        private ReportRepository reportRepository;


        public DbReposSQL()
        {
            db = new Model();
        }

        public IRepository<COMMONDITY> COMMONDITY
        {
            get
            {
                if (commondityRepository == null)
                    commondityRepository = new CommondityRepository(db);
                return commondityRepository;
            }
        }

        public IRepository<COMMONDITY_TYPE_REF> COMMONDITY_TYPE_REF
        {
            get
            {
                if (commondityTypeRepository == null)
                    commondityTypeRepository = new CommondityTypeRepository(db);
                return commondityTypeRepository;
            }
        }

        public IRepository<PROVIDER> PROVIDER 
        {
            get
            {
                if (providerRepository == null)
                    providerRepository = new ProviderRepository(db);
                return providerRepository;
            }
        }

        public IRepository<PROVIDER_SUPPLY_STOCK> PROVIDER_SUPPLY_STOCK
        {
            get
            {
                if (providerSupplyRepository == null)
                   providerSupplyRepository  = new ProviderSupplyStockRepository(db);
                return providerSupplyRepository;
            }
        }

        public IRepository<SUPPLY> SUPPLY 
        {
            get
            {
                if (supplyRepository == null)
                    supplyRepository = new SupplyRepository(db);
                return supplyRepository;
            }
        }

        public IRepository<SUPPLY_LINE> SUPPLY_LINE
        {
            get
            {
                if (supplyLineRepository == null)
                    supplyLineRepository = new SupplyLineRepository(db);
                return supplyLineRepository;
            }
        }

        public IRepository<SUPPLY_STATUS_REF> SUPPLY_STATUS_REF
        {
            get
            {
                if (supplyStatusRefRepository == null)
                    supplyStatusRefRepository = new SupplyStatusRefRepository(db);
                return supplyStatusRefRepository;
            }
        }

        public IRepository<USER> USER
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<WAREHOUSE> WAREHOUSE 
        {
            get
            {
                if (warehouseRepository == null)
                    warehouseRepository = new WarehouseRepository(db);
                return warehouseRepository;
            }
        }

        public IRepository<WAREHOUSE_LINE> WAREHOUSE_LINE
        {
            get
            {
                if (warehouseLineRepository == null)
                    warehouseLineRepository = new WarehouseLineRepository(db);
                return warehouseLineRepository;
            }
        }

        public ISupplyRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepository(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
