using MVVMvideo04part04.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo04part04.ViewModels
{
    internal class CountriesStatisticViewModel:ViewModel
    {
        private readonly MainWindowViewModel _MainModel;

        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
            _MainModel = MainModel;
        }

    }
}
