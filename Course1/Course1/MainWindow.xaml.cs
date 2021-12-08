﻿using System;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBDataOperation dbcontext = new DBDataOperation();
        List<Commondity> allCommon;
        List<CommondityType> allCommonType;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            allCommon = dbcontext.GetAllCommondity();
            allCommonType = dbcontext.GetAllCommondityType();

            CommondityData.ItemsSource = allCommon;
            SupplyData.ItemsSource = SupplyService.SupplyList();
            WarehouseData.ItemsSource = SupplyService.createWarehouseLine();

            CB.ItemsSource = allCommonType;
            CB.DisplayMemberPath = "Type";
            CB.SelectedValuePath = "Id";
            
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {


            for (int i = 0; i < CommondityData.Items.Count; i++)
            {
                Commondity c = new Commondity
                {
                    Id = int.Parse((CommondityData.Columns[0].GetCellContent(CommondityData.Items[i]) as TextBlock).Text),
                    Name = (CommondityData.Columns[1].GetCellContent(CommondityData.Items[i]) as TextBlock).Text,
                    CommondityType = (CommondityData.Columns[2].GetCellContent(CommondityData.Items[i]) as ComboBox).SelectedIndex + 1,
                    Size = int.Parse((CommondityData.Columns[3].GetCellContent(CommondityData.Items[i]) as TextBlock).Text)
                };
                dbcontext.UpdateCommondity(c);
            }

            CommondityData.ItemsSource = allCommon;
            MessageBox.Show("Изменения сохранены");
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            CreateCommondityWindow ccw = new CreateCommondityWindow();
            ccw.CBCommondity.ItemsSource = allCommonType;
            ccw.CBCommondity.DisplayMemberPath = "Type";
            //ccw.CBCommondity.SelectedValuePath = "Id";

            ccw.ShowDialog();
            if (ccw.DialogResult.Value) return;

            Commondity c = new Commondity();
            c.Name = ccw.TBCommondity.Text;
            c.CommondityType = ccw.CBCommondity.SelectedIndex + 1;
            c.Size = int.Parse(ccw.CBCommonditySize.Text);

            dbcontext.CreateCommondity(c);
            allCommon = dbcontext.GetAllCommondity();
            CommondityData.ItemsSource = allCommon;

            MessageBox.Show("Новый товар добавлен");
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            var index = CommondityData.SelectedIndex;
            if (index != -1)
            {
                dbcontext.DeleteCommondity(Int32.Parse((CommondityData.Columns[0].GetCellContent(CommondityData.Items[index]) as TextBlock).Text));
                allCommon = dbcontext.GetAllCommondity();
                CommondityData.ItemsSource = allCommon;
            }
            else MessageBox.Show("Ни один элемент не выбран!");
        }

        private void ChangeSupply(object sender, RoutedEventArgs e)
        {

        }

        private void AddSupply(object sender, RoutedEventArgs e)
        {
            CreateSupplyWindow supplyWindow = new CreateSupplyWindow();
            supplyWindow.Show();
            SupplyData.ItemsSource = SupplyService.SupplyList();
        }

        private void DeleteSupply(object sender, RoutedEventArgs e)
        {
            var index = SupplyData.SelectedIndex;
            if (index != -1)
            {            
                dbcontext.DeleteSupply(Int32.Parse((SupplyData.Columns[0].GetCellContent(SupplyData.Items[index]) as TextBlock).Text));
                SupplyData.ItemsSource = SupplyService.SupplyList();
            }
            else MessageBox.Show("Ни один элемент не выбран!");
        }
    }
}
