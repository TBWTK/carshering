using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carshering.Core;

namespace carshering.MVVM.ViewModel
{
    class AuthenticationViewModel : ObservableObjects
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

        public LoginViewModel LoginVM { get; set; }
        public RelayCommand LoginViewCommand { get; set; }

        public RegistrationViewModel RegistrationVM { get; set; }
        public RelayCommand RegistrationViewCommand { get; set; }

        public AuthenticationViewModel()
        {
            LoginVM = new LoginViewModel();
            RegistrationVM = new RegistrationViewModel();

            CurrentView = LoginVM;

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVM;
            });

            RegistrationViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegistrationVM;
            });
        }
    }
}
