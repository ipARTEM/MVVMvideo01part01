using MVVMvideo04part04.Services;
using MVVMvideo04part04.ViewModels.Base;
using MVVMvideo04part04.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MVVMvideo04part04.Models;
using System.Linq;

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

        #region
        private CountryInfo _SelectedCountry;

        public CountryInfo SelectedCountry
        {
            get { return _SelectedCountry; }
            set => Set(ref _SelectedCountry, value);
        }



        #endregion


        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataService.GetData();
        }

        #endregion


        /// <summary>
        /// Отладочный конструктор, используемый в процессе разработки в визуальном дизайнере
        /// </summary>
        public CountriesStatisticViewModel():this(null)
        {
            if (App.IsDesingMode)
                throw new InvalidOperationException("Вызов конструктора, непредназначенного для использования в обычном режиме");
            _Countries = Enumerable.Range(1, 10)
                .Select(i => new CountryInfo
                {
                    Name = $"Country{i}",
                    ProvinceCounts=Enumerable.Range(1,10).Select(j=> new PlaceInfo
                    {
                        Name =$"Province {i}",
                        Location=new System.Windows.Point(i,j),
                        Counts=Enumerable.Range(1,10).Select(k=>new ConfirmedCount 
                        {
                            Date=DateTime.Now.Subtract(TimeSpan.FromDays(100-j)),
                            Count=k
                        }).ToArray()
                    }).ToArray()

                }).ToArray();

        }


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
