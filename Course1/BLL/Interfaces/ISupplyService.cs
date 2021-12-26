using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;

namespace BLL.Interfaces
{
    public interface ISupplyService
    {
        List<SupplyService.CreateSupplyData> WarehouseCheck(int idProv);
        bool MakeSupply(List<SupplyService.CreateSupplyData> csd);
        List<SupplyService.CreateWarehouse> createWarehouseLine();

    }
}
