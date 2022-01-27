using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "asdakjdkljdfa";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
