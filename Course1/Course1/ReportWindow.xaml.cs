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
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        public ReportWindow(List<SupplyService.CreateSupplyData> c)
        {
            InitializeComponent();

            DataLabel.Content += (DateTime.Now).ToString();
            for (int i = 0; i < c.Count;i++)
            {
               NamberLabel.Content += "\n" + (i+1);
            }
            c.Select(i => NameLabel.Content += "\n" + i.Name).ToList();
            c.Select(i => CostLabel.Content += "\n" + i.Cost).ToList();
            c.Select(i => CountLabel.Content += "\n" + i.Quantity).ToList();
            c.Select(i => SumLabel.Content += "\n" + i.Cost * i.Quantity).ToList();

            PrintDialog dialog = new PrintDialog();
            dialog.PrintVisual(this.Report, "Накладная");
        }
    }
}
