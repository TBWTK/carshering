using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carshering.Core;

namespace carshering.MVVM.ViewModel
{
    class MainViewModel : ObservableObjects
    {
        private object _currentView;
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public CarTrackingViewModel CarTrackingVM { get; set; }
        public RelayCommand CarTrackingViewCommand { get; set; }

        public MainViewModel()
        {
            CarTrackingVM = new CarTrackingViewModel();

            CurrentView = CarTrackingVM;

            CarTrackingViewCommand = new RelayCommand(o =>
            {
                CurrentView = CarTrackingVM;
            });
        }

    }
}
