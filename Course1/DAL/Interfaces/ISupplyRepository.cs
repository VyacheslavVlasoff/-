using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISupplyRepository
    {
        List<CreateSupplyData> WarehouseCheck(int idProv);
        bool MakeSupply(List<CreateSupplyData> csd);
        List<CreateWarehouse> createWarehouseLine();
    }
}
