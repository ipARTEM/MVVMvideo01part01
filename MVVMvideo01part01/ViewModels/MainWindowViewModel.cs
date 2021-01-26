using MVVMvideo04part04.Infrastructure.Commands;
using MVVMvideo04part04.Models;
using MVVMvideo04part04.Models.Decanat;
using MVVMvideo04part04.ViewModels.Base;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMvideo04part04.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        //************************************************************************

        private readonly CountriesStatisticViewModel _CountriesStatistic;


        //************************************************************************
        public ObservableCollection<Group> Groups { get; }



        #region Свойства


        #region SelectedGroup
        /// <summary>
        /// SelectedGroup 
        /// </summary>
        private Group _SelectedGroup;

        public Group SelectedGroup
        {
            get { return _SelectedGroup; }
            set
            {
                if(!Set(ref _SelectedGroup, value)) return;
                _SelectedGroupStudents.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudents));   // уведомим о том что изменилось свойство
            }
        }
        #endregion

        #region StudentFilterText Текст фильтра студентов
        private string _StudentFilterText;

        public string StudentFilterText
        {
            get=> _StudentFilterText; 
            set
            {
               if(! Set(ref _StudentFilterText, value)) return;
                _SelectedGroupStudents.View.Refresh();
            }
        }
        #endregion



        #region OnStudentFiltred        Логика фильтрации для DataGrid

        private readonly CollectionViewSource _SelectedGroupStudents=new CollectionViewSource();

        private void OnStudentFiltred(object sender, FilterEventArgs e)
        {
           if(!(e.Item is Student student))
            {
                e.Accepted = false;
                return;
            }

            var filter_text = _StudentFilterText;
            if (string.IsNullOrWhiteSpace(filter_text)) return;

           if(student.Name is null|| student.Surname is null|| student.Patronymic is null)
            {
                e.Accepted = false;
                return;
            }

            if (student.Name.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

            if (student.Surname.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

            if (student.Patronymic.Contains(filter_text, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;

        }

        public ICollectionView SelectedGroupStudents => _SelectedGroupStudents?.View;

        #endregion



        #region SelectedPageIndex : int - Номер выбранной вкладки

        /// <summary>Номер выбранной вкладки</summary>
        private int _SelectedPageIndex = 1;

        /// <summary>Номер выбранной вкладки</summary>
        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }

        #endregion

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


        #region Тестовый набор данных для визуализации графиков

        /// <summary>
        /// Тестовый набор данных для визуализации графиков
        /// </summary>
        private IEnumerable<Models.DataPoint> _TestDataPoints;

        public IEnumerable<Models.DataPoint> TestDataPoints
        {
            get { return _TestDataPoints; }
            set => Set(ref _TestDataPoints, value);
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

        #region Тест мах оперативки
        public IEnumerable<Student> TestStudent => 
            Enumerable.Range(1, App.IsDesingMode?15:100)        // Выбор показывать кол-во студентов в зависимости от (дизайнер или сборка программы)
            .Select(i => new Student
            {
                Name = $"Имя{i}",
                Surname = $"Фамилия{i}"
            });
        #endregion


        #endregion

        //**************************************************************************************//
        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            //(RootObject as Window)?.Close();
            Application.Current.Shutdown();

            //var items = new string[10];       // Работает только на Core
            //var last_item = items[^2];
        }

        #endregion


        #region ChangeTabIndexCommand

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion

        #region CreateGroupCommand
        public ICommand CreateGroupCommand { get; }

        private bool CanCreateGroupCommandExecute(object p) => true;

        private void OnCreateGroupCommandExecuted(object p)
        {
            var group_max_index = Groups.Count + 1;
            var new_grup = new Group
            {

                Name = $"Группа {group_max_index}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(new_grup);
        }

        #endregion

        #region DeleteGroupCommand
        public ICommand DeleteGroupCommand { get; }

        private bool CanDeleteGroupCommandExecute(object p) => p is Group group && Groups.Contains(group);

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is Group group)) return;
            var group_index = Groups.IndexOf(group);
            Groups.Remove(group);
            if (group_index < Groups.Count)
            {
                if ((group_index - 1) >= 0)
                    SelectedGroup = Groups[group_index - 1];
                else
                    SelectedGroup = Groups[group_index];

            }
        }

        #endregion

        #endregion


        public MainWindowViewModel()
        {
            _CountriesStatistic = new  CountriesStatisticViewModel(this);


            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);

            CreateGroupCommand = new LambdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);

            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);

            #endregion
            var data_points = new List<Models.DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new Models.DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;

            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа{i}",
                Students = new ObservableCollection<Student>(students)

            });

            Groups = new ObservableCollection<Group>(groups);

            //Добавление фильтра
            _SelectedGroupStudents.Filter += OnStudentFiltred;

            //Упорядочивание новой коллекции в обратном порядке
            _SelectedGroupStudents.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));

            //Группировка данных
            _SelectedGroupStudents.GroupDescriptions.Add(new PropertyGroupDescription("Name"));

        }

   
    }
}
