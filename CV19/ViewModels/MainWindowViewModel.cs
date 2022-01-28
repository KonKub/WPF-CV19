using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion

            var dp = new List<DataPoint>((int)(360/0.1));
            for (var x = 0d; x <= 360; x = x + 0.1)
            {
                var y = Math.Sin(x * Math.PI / 180);
                dp.Add(new DataPoint { XValue = x, YValue = y });
            }
            TestDataPoints = dp;
        }

        #region IEnumerable<DataPoint> TestDataPoints Тестовые данные для построения графика
        /// <summary> Тестовые данные для построения графика </summary>
        private IEnumerable<DataPoint> _TestDataPoints;

        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }
        #endregion

        #region string _title заголовок окна
        /// <summary> заголовок окна </summary>
        private string _title = "asdakjdkljdfa";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region string _title статус программы
        /// <summary> Статус программы </summary>
        private string _status = "Готов!!!";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion

        #endregion
    }
}
