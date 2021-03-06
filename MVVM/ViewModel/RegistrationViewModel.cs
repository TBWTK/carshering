using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using carshering.Core;
using carshering.MVVM.View;

namespace carshering.MVVM.ViewModel
{
    class Gender
    // Класс для примера реализации, будет удален при подключении базы данных
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Role
    // Класс для примера реализации, будет удален при подключении базы данных
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class RegistrationViewModel : ObservableObjects
    {

        public List<Gender> Genders { get; set; }
        public List<Role> Roles { get; set; }


        public RelayCommand CreateUser { get; set; }

        public RegistrationViewModel()
        {
            Genders = new List<Gender>()
            {
                new Gender(){ Id = 1, Name = "мужской"},
                new Gender(){ Id = 2, Name = "женский" }
            };
            Roles = new List<Role>()
            {
                new Role(){ Id = 1, Name = "админ"},
                new Role(){ Id = 2, Name = "кто то еще" }
            };

            CreateUser = new RelayCommand(o =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();

                //var us = db.User.All(u => u.name == Login && u.password == Password);
                //if (us)
                //{
                //    MessageBox.Show("вы вошли в систему");
                //}
                //else
                //{
                //    MessageBox.Show("данные неверны");

                //}
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

        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get => _ConfirmPassword;
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged("ConfirmPassword");

            }
        }


        //private Calendar _DateUser;
        //public Calendar DateUser
        //{
        //    get => _DateUser;
        //    set
        //    {
        //        _DateUser = value;
        //        OnPropertyChanged("DateUser");

        //    }
        //}
    }
}
