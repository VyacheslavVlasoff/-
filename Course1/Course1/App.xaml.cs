using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration.Install;
using Castle.Windsor;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using VDA.Util;
using Ninject;

namespace Course1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("Model1"));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            ISupplyService orderServ = kernel.Get<ISupplyService>();

            MainWindow window = new MainWindow(crudServ, orderServ);
            window.Show();
        }
    }
}
