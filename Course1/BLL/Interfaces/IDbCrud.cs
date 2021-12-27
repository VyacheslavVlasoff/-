using System.Collections.Generic;
using BLL.Models;
using BLL.Services;

namespace BLL.Interfaces
{
    public interface IDbCrud

    {
        List<Commondity> GetAllCommondity();
        Commondity GetCommondity(int Id);
        void CreateCommondity(Commondity item);
        void UpdateCommondity(Commondity item);
        void DeleteCommondity(int Id);

        List<CommondityType> GetAllCommondityType();

        List<Supply> GetAllSupply();
        Supply GetSupply(int Id);
        void UpdateSupply(Supply item);
        void DeleteSupply(int Id);

        List<SupplyLine> GetAllSupplyLines();
        SupplyLine GetSupplyLine(int Id);
        void DeleteSupplyLine(int Id);

        List<Warehouse> GetAllWarehouse();

        List<WarehouseLine> GetAllWarehouseLine();
        WarehouseLine GetWarehouseLine(int Id);
        void UpdateWarehouseLine(List<SupplyService.CreateSupplyData> item);

        List<Providers> GetAllProviders();

        List<ProviderSupplyStock> GetAllProviderSupplyStock();
        void CreateProviderSupplyStock(ProviderSupplyStock item);
        void DeleteProviderSupplyStock(int Id);
        void UpdateProviderSupplyStock(ProviderSupplyStock item);
        void UpdateProviderSupplyStock(int ID, bool k);

        List<Status> GetAllStatus();
    }
}
