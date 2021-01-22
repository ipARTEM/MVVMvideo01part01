using MVVMvideo04part04.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMvideo04part04
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesingMode { get; private set; } = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesingMode = false;

            base.OnStartup(e);

            var service_test = new DataService();

            var countries = service_test.GetData().ToArray();
        }


    }
}
