using MVVMvideo01part01.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMvideo01part01.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region Заголовок окна

        private string _Title = "Тест Core";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();

            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }

        #endregion


        #region  Статус программы
        /// <summary>
        /// Статус программы
        /// </summary>
        private string _Status = "Готов!!";

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

    }
}
