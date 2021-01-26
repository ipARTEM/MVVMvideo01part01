using MVVMvideo04part04.Services;
using MVVMvideo04part04.ViewModels.Base;
using MVVMvideo04part04.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MVVMvideo04part04.Models;

namespace MVVMvideo04part04.ViewModels
{
    internal class CountriesStatisticViewModel : ViewModel
    {
        private DataService _DataService;

        private MainWindowViewModel MainModel { get; }

        #region Статистика по странам

        /// <summary>Статистика по странам</summary>
        private IEnumerable<CountryInfo> _Countries;

        /// <summary>Статистика по странам</summary>
        public IEnumerable<CountryInfo> Countries 
        {
            get => _Countries;
            private set => Set(ref _Countries, value);
        }

        #endregion


        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataService.GetData();
        }

        #endregion


        public CountriesStatisticViewModel(MainWindowViewModel MainModel)
        {
            this.MainModel = MainModel;

            _DataService = new DataService();

            #region Команды

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }

    }
}
