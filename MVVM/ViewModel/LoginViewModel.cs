using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using carshering.Core;

namespace carshering.MVVM.ViewModel
{
    class LoginViewModel : ObservableObjects
    {

        public RelayCommand EntrySystem { get; set; }

        public LoginViewModel()
        {

            EntrySystem = new RelayCommand(o => 
            {
                //Код для входа в систему
            });
        }
        private string _Login;
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
