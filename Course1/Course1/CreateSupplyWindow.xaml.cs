using System;
using BLL;
using BLL.Services;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Course1
{
    /// <summary>
    /// Логика взаимодействия для CreateSupplyWindow.xaml
    /// </summary>
    public partial class CreateSupplyWindow : Window
    {
        ISupplyService service;
        IDbCrud dbcontext;

        public CreateSupplyWindow(IDbCrud dbOperations, ISupplyService supplyService)
        {
            InitializeComponent();
            dbcontext = dbOperations;
            service = supplyService;

            CB.ItemsSource = dbcontext.GetAllProviders();
            CB.DisplayMemberPath = "CompanyName";
            CB.SelectedValuePath = "Id";
            CB.SelectedIndex = 0;

            CBWarehouse.ItemsSource = dbcontext.GetAllWarehouse();
            CBWarehouse.DisplayMemberPath = "Addres";
            CBWarehouse.SelectedValuePath = "Id";
            CBWarehouse.SelectedIndex = 0;

            CreateSupplyData.ItemsSource = service.WarehouseCheck(CB.SelectedIndex+1);
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            List<SupplyService.CreateSupplyData> csd = new List<SupplyService.CreateSupplyData>();
            csd = service.WarehouseCheck(CB.SelectedIndex + 1);

            for (int i = 0; i < CreateSupplyData2.Items.Count; i++)
            {
                csd.Where(l => l.Name == (CreateSupplyData2.Columns[1].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text
                && l.Size == int.Parse((CreateSupplyData2.Columns[3].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text)
                && l.ProviderId == CB.SelectedIndex + 1)
                .Select(l => l.check = true).ToList();
                csd.Where(l => l.Name == (CreateSupplyData2.Columns[1].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text
                && l.Size == int.Parse((CreateSupplyData2.Columns[3].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text)
                && l.ProviderId == CB.SelectedIndex + 1)
                .Select(l => l.Quantity = int.Parse((CreateSupplyData2.Columns[6].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text)).ToList();
            }

            service.MakeSupply(csd, CBWarehouse.SelectedIndex + 1);
            MessageBox.Show("Поставка успешно создана");
            MainWindow mw = new MainWindow(dbcontext, service);
            mw.SupplyData.ItemsSource = dbcontext.GetAllSupply();
            mw.WarehouseData.ItemsSource = service.createWarehouseLine();

            ReportWindow rw = new ReportWindow(csd.Where(i => i.check == true).ToList());
            rw.Show();
            Close();

        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            List<SupplyService.CreateSupplyData> csd = new List<SupplyService.CreateSupplyData>();
            csd = service.WarehouseCheck(CB.SelectedIndex+1);
           
            for (int i = 0; i < CreateSupplyData.Items.Count; i++)
            {
                CheckBox mycheckbox = CreateSupplyData.Columns[0].GetCellContent(CreateSupplyData.Items[i]) as CheckBox;
                if (mycheckbox.IsChecked == true)
                {
                    csd.Where(l => l.Name == (CreateSupplyData.Columns[1].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text
                    && l.Size == int.Parse((CreateSupplyData.Columns[3].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text))
                        .Select(l => l.check = true).ToList();
                    //CheckB2 = mycheckbox;
                }
                else
                    csd.Where(l => l.Name == (CreateSupplyData.Columns[1].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text
                   && l.Size == int.Parse((CreateSupplyData.Columns[3].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text))
                       .Select(l => l.check = false).ToList();
            }
            CreateSupplyData2.ItemsSource = csd.Where(l => l.check == true).ToList();
           // MessageBox.Show("Карзина обновлена");
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            List<SupplyService.CreateSupplyData> csd = new List<SupplyService.CreateSupplyData>();
            csd = service.WarehouseCheck(CB.SelectedIndex+1);

            for (int i = 0; i < CreateSupplyData2.Items.Count; i++)
            {
                CheckBox mycheckbox = CreateSupplyData2.Columns[0].GetCellContent(CreateSupplyData2.Items[i]) as CheckBox;
                if (mycheckbox.IsChecked == true)
                {
                    csd.Where(l => l.Name == (CreateSupplyData2.Columns[1].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text
                    && l.Size == int.Parse((CreateSupplyData2.Columns[3].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text))
                        .Select(l => l.check = true).ToList();
                }
                else
                    csd.Where(l => l.Name == (CreateSupplyData2.Columns[1].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text
                    && l.Size == int.Parse((CreateSupplyData2.Columns[3].GetCellContent(CreateSupplyData2.Items[i]) as TextBlock).Text))
                        .Select(l => l.check = false).ToList();
            }
            CreateSupplyData2.ItemsSource = csd.Where(l => l.check == true).ToList();
            // MessageBox.Show("Карзина обновлена");
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateSupplyData.ItemsSource = service.WarehouseCheck(CB.SelectedIndex + 1);
        }

        private void CreateSupplyData2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateSupplyData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
