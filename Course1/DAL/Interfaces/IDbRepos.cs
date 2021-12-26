using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<COMMONDITY> COMMONDITY { get; }
        IRepository<COMMONDITY_TYPE_REF> COMMONDITY_TYPE_REF { get; }
        IRepository<PROVIDER> PROVIDER { get; }
        IRepository<PROVIDER_SUPPLY_STOCK> PROVIDER_SUPPLY_STOCK { get; }
        IRepository<SUPPLY> SUPPLY { get; }
        IRepository<SUPPLY_LINE> SUPPLY_LINE { get; }
        IRepository<SUPPLY_STATUS_REF> SUPPLY_STATUS_REF { get; }
        IRepository<USER> USER { get; }
        IRepository<WAREHOUSE> WAREHOUSE { get; }
        IRepository<WAREHOUSE_LINE> WAREHOUSE_LINE { get; }
        ISupplyRepository Reports { get; }
    int Save();
    }
}
