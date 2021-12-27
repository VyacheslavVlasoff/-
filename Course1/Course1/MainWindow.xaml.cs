using System;
using BLL;
using BLL.Services;
using BLL.Models;
using BLL.Interfaces;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

namespace Course1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISupplyService service;
        IDbCrud dbcontext;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public MainWindow(IDbCrud crudDb, ISupplyService supplyservice)
        {
            service = supplyservice;
            dbcontext = crudDb;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        { 
            CommondityData.ItemsSource = dbcontext.GetAllProviderSupplyStock();
            CoBo.ItemsSource = dbcontext.GetAllCommondity(); ;
            CoBo.DisplayMemberPath = "Name";
            CoBo.SelectedValuePath = "Id";

            CoBo2.ItemsSource = dbcontext.GetAllProviders(); ;
            CoBo2.DisplayMemberPath = "CompanyName";
            CoBo2.SelectedValuePath = "Id";
            
            SupplyData.ItemsSource = dbcontext.GetAllSupply();
            WarehouseData.ItemsSource = service.createWarehouseLine();

            StatusBox.ItemsSource = dbcontext.GetAllStatus();
            StatusBox.DisplayMemberPath = "StatusSup";
            StatusBox.SelectedValuePath = "Id";
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < CommondityData.Items.Count; i++)
            {
                ProviderSupplyStock c = new ProviderSupplyStock
                {
                    Id = int.Parse((CommondityData.Columns[0].GetCellContent(CommondityData.Items[i]) as TextBlock).Text),
                    CommondityId = int.Parse((CommondityData.Columns[1].GetCellContent(CommondityData.Items[i]) as ComboBox).SelectedValue.ToString()),
                    ProviderId = (CommondityData.Columns[2].GetCellContent(CommondityData.Items[i]) as ComboBox).SelectedIndex + 1,
                    Cost = decimal.Parse((CommondityData.Columns[3].GetCellContent(CommondityData.Items[i]) as TextBlock).Text)
                };
                dbcontext.UpdateProviderSupplyStock(c);
            }

            for (int i = 0; i < CommondityData.Items.Count - 1; i++)
            {
                for (int j = i + 1; j < CommondityData.Items.Count; j++)
                {
                    var sr1 = (CommondityData.Columns[1].GetCellContent(CommondityData.Items[i]) as ComboBox).SelectedIndex;
                    var sr2 = (CommondityData.Columns[1].GetCellContent(CommondityData.Items[j]) as ComboBox).SelectedIndex;
                    var sr3 = (CommondityData.Columns[2].GetCellContent(CommondityData.Items[i]) as ComboBox).SelectedIndex;
                    var sr4 = (CommondityData.Columns[2].GetCellContent(CommondityData.Items[j]) as ComboBox).SelectedIndex;
                    if (sr1 == sr2 && sr3 != sr4)
                    {
                        var s1 = int.Parse((CommondityData.Columns[3].GetCellContent(CommondityData.Items[i]) as TextBlock).Text);
                        var s2 = int.Parse((CommondityData.Columns[3].GetCellContent(CommondityData.Items[j]) as TextBlock).Text);
                        var idv1 = int.Parse((CommondityData.Columns[0].GetCellContent(CommondityData.Items[i]) as TextBlock).Text);
                        var idv2 = int.Parse((CommondityData.Columns[0].GetCellContent(CommondityData.Items[j]) as TextBlock).Text);
                        if (s1 < s2)
                        {
                            dbcontext.UpdateProviderSupplyStock(idv1, true);
                            dbcontext.UpdateProviderSupplyStock(idv2, false);
                        }
                        else
                        {
                            dbcontext.UpdateProviderSupplyStock(idv2, true);
                            dbcontext.UpdateProviderSupplyStock(idv1, false);
                        }
                    }
                }
            }
            CommondityData.ItemsSource = dbcontext.GetAllProviderSupplyStock();
            MessageBox.Show("Изменения сохранены");
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            CreateCommondityWindow ccw = new CreateCommondityWindow();
            ccw.CBCommondity.ItemsSource = dbcontext.GetAllCommondity();
            ccw.CBCommondity.DisplayMemberPath = "Name";
            ccw.CBProvider.ItemsSource = dbcontext.GetAllProviders();
            ccw.CBProvider.DisplayMemberPath = "CompanyName";

            ccw.ShowDialog();
            if (ccw.DialogResult.Value) return;

            ProviderSupplyStock c = new ProviderSupplyStock();
            c.CommondityId = ccw.CBCommondity.SelectedIndex+1;
            c.ProviderId = ccw.CBProvider.SelectedIndex + 1;
            c.Cost = decimal.Parse(ccw.TBCost.Text);

            dbcontext.CreateProviderSupplyStock(c);

            CommondityData.ItemsSource = dbcontext.GetAllProviderSupplyStock();

            MessageBox.Show("Новый товар добавлен");
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            var index = CommondityData.SelectedIndex;
            if (index != -1)
            {
                dbcontext.DeleteProviderSupplyStock(Int32.Parse((CommondityData.Columns[0].GetCellContent(CommondityData.Items[index]) as TextBlock).Text));
                CommondityData.ItemsSource = dbcontext.GetAllProviderSupplyStock();
            }
            else MessageBox.Show("Ни один элемент не выбран!");
        }

        private void ChangeSupply(object sender, RoutedEventArgs e)
        {

        }

        private void AddSupply(object sender, RoutedEventArgs e)
        {
            CreateSupplyWindow supplyWindow = new CreateSupplyWindow(dbcontext, service);
            supplyWindow.Show();

            SupplyData.ItemsSource = dbcontext.GetAllSupply();
            WarehouseData.ItemsSource = service.createWarehouseLine();
        }

        private void DeleteSupply(object sender, RoutedEventArgs e)
        {
            var index = SupplyData.SelectedIndex;
            if (index != -1)
            {
                dbcontext.DeleteSupplyLine(Int32.Parse((SupplyData.Columns[0].GetCellContent(SupplyData.Items[index]) as TextBlock).Text));
                dbcontext.DeleteSupply(Int32.Parse((SupplyData.Columns[0].GetCellContent(SupplyData.Items[index]) as TextBlock).Text));
                SupplyData.ItemsSource = dbcontext.GetAllSupply();
            }
            else MessageBox.Show("Ни один элемент не выбран!");
        }

        private void SupplyData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = SupplyData.SelectedIndex;
            if (i != -1)
            {
                Supply c = dbcontext.GetSupply(int.Parse((SupplyData.Columns[0].GetCellContent(SupplyData.Items[i]) as TextBlock).Text));
                c.Status = (SupplyData.Columns[4].GetCellContent(SupplyData.Items[i]) as ComboBox).SelectedIndex + 1;
                dbcontext.UpdateSupply(c);
                if (c.DeliveryDate == null &&
                    (SupplyData.Columns[4].GetCellContent(SupplyData.Items[i]) as ComboBox).SelectedIndex + 1 == 3)
                {
                    c.DeliveryDate = DateTime.Now;
                    c.Status = (SupplyData.Columns[4].GetCellContent(SupplyData.Items[i]) as ComboBox).SelectedIndex + 1;
                    dbcontext.UpdateSupply(c);
                    SupplyData.ItemsSource = dbcontext.GetAllSupply();
                }

            }
        }

        private void CommondityData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
