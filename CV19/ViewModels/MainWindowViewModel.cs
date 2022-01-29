using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

using System.Timers;
//using OxyPlot;
using OxyPlot.Series;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private LineSeries lineSeries;
        public OxyPlot.PlotModel Plot { get; private set; }


        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion


            Plot = new OxyPlot.PlotModel { Title = "Example 1" };
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            //this.MyModel.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));

            lineSeries = new LineSeries();
            lineSeries.LineStyle = OxyPlot.LineStyle.Solid;
            lineSeries.StrokeThickness = 2.0;
            lineSeries.Color = OxyPlot.OxyColor.FromRgb(0, 0, 0);

            Plot.Series.Add(lineSeries);

            for (var x = 0d; x <= 360; x = x + 0.1)
            {
                var y = Math.Sin(x * Math.PI / 180);
                lineSeries.Points.Add(new OxyPlot.DataPoint(x, y));
            }

            //Timer timer = new Timer(1000);
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();
            //count = 0;
        }

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


        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    lineSeries.Points.Add(new OxyPlot.DataPoint(count, Math.Pow(count, 2)));
        //    this.MyModel.InvalidatePlot(true);

        //    count++;
        //}

    }
}
