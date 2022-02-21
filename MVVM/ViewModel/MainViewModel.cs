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

        public AccountViewModel AccountVM { get; set; }
        public RelayCommand AccountViewCommand { get; set; }

        public MainViewModel()
        {
            CarTrackingVM = new CarTrackingViewModel();
            AccountVM = new AccountViewModel();

            CurrentView = CarTrackingVM;

            CarTrackingViewCommand = new RelayCommand(o =>
            {
                CurrentView = CarTrackingVM;
            });

            AccountViewCommand = new RelayCommand(o =>
            {
                CurrentView = AccountVM;
            });
        }

    }
}
