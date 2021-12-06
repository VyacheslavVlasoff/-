using System;
using BLL;
using BLL.Services;
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
        DBDataOperation dbcontext = new DBDataOperation();

        public CreateSupplyWindow()
        {
            InitializeComponent();

            CreateSupplyData.ItemsSource = SupplyService.WarehouseCheck();
            //CreateSupplyData.ItemsSource = dbcontext.GetAllCommondity();
            //CreateSupplyData2.ItemsSource = dbcontext.GetAllCommondity();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            List<SupplyService.CreateSupplyData> csd = new List<SupplyService.CreateSupplyData>();
            csd = SupplyService.WarehouseCheck();

            for (int i = 0; i < CreateSupplyData2.Items.Count; i++)
            {
                    csd.Where(l => l.Name == (CreateSupplyData.Columns[1].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text
                    && l.Size == int.Parse((CreateSupplyData.Columns[3].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text))
                    .Select(l => l.check = true).ToList();
            }

            //Supply order = new Supply
            //{
            //    ProviderId = 1,
            //    WarehouseId = 1,
            //    ApplicantId = 1,
            //    StatusId = 2,
            //    ApplicationDate = DateTime.Now
            //};
            csd.Select(l => l.Quantity = 1).ToList();

            SupplyService.MakeSupply(csd);
            MainWindow mw = new MainWindow();
            mw.SupplyData.ItemsSource = SupplyService.SupplyList();
            MessageBox.Show("Поставка успешно создана");
            Close();

        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            int k = 0;
            int[] mass = new int[1000];
            List<SupplyService.CreateSupplyData> csd = new List<SupplyService.CreateSupplyData>();
            csd = SupplyService.WarehouseCheck();
           
            for (int i = 0; i < CreateSupplyData.Items.Count; i++)
            {
                CheckBox mycheckbox = CreateSupplyData.Columns[0].GetCellContent(CreateSupplyData.Items[i]) as CheckBox;
                if (mycheckbox.IsChecked == true)
                {
                    csd.Where(l => l.Name == (CreateSupplyData.Columns[1].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text
                    && l.Size == int.Parse((CreateSupplyData.Columns[3].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text))
                        .Select(l => l.check = true).ToList();
                }
                //else csd.Where(l => l.Name == (CreateSupplyData.Columns[1].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text
                //    && l.Size == int.Parse((CreateSupplyData.Columns[3].GetCellContent(CreateSupplyData.Items[i]) as TextBlock).Text))
                //    .Select(l => l.check = false).ToList();
            }
            CreateSupplyData2.ItemsSource = csd.Where(l => l.check == true);
           // MessageBox.Show("Карзина обновлена");
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {

        }
    }
}
