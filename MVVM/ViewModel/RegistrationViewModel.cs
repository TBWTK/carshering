using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using carshering.Core;

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
        public RelayCommand DownloadImage { get; set; }

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


            Image = new Image();


            DownloadImage = new RelayCommand(o =>
            {
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                Microsoft.Win32.OpenFileDialog ofdPicture = new Microsoft.Win32.OpenFileDialog();
                ofdPicture.Filter =
                    "Image files|*.bmp;*.jpg;*.JPG;*.gif;*.png;*.tif|All files|*.*";
                ofdPicture.FilterIndex = 1;

                if (ofdPicture.ShowDialog() == true)
                {
                    myBitmapImage.UriSource = new Uri(ofdPicture.FileName);
                    myBitmapImage.EndInit();
                    Image.Source = myBitmapImage;
                }
            });

            CreateUser = new RelayCommand(o =>
            {

                if(NodeCategoryRole != null && NodeCategoryGender != null)
                {
                    string ex = Login + "  " + Password + "  " + NodeCategoryRole.Name + "  " + NodeCategoryGender.Name;
                    System.Windows.MessageBox.Show(ex);
                }
                else
                {
                    System.Windows.MessageBox.Show("Введены неверные данные");
                }
            });
        }
        
        private Image _Image;
        public Image Image
        {
            get => _Image;
            set
            {
                _Image = value;
                OnPropertyChanged("Image");
            }
        }

        private Gender _NodeCategoryGender;
        public Gender NodeCategoryGender
        {
            get
            {
                return _NodeCategoryGender;
            }
            set
            {
                _NodeCategoryGender = value;
                OnPropertyChanged("NodeCategoryGender");
            }
        }

        private Role _NodeCategoryRole;
        public Role NodeCategoryRole
        {
            get
            {
                return _NodeCategoryRole;
            }
            set
            {
                _NodeCategoryRole = value;
                OnPropertyChanged("NodeCategoryRole");
            }
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

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged("Name");

            }
        }

        private string _SecondName;
        public string SecondName
        {
            get => _SecondName;
            set
            {
                _SecondName = value;
                OnPropertyChanged("SecondName");

            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                OnPropertyChanged("LastName");

            }
        }

        private int _Age;
        public int Age
        {
            get => _Age;
            set
            {
                _Age = value;
                OnPropertyChanged("Age");

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
