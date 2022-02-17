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


            image = new Image();

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
                    image.Source = myBitmapImage;
                }
            });
        }
        
        private Image _image;
        public Image image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged("image");
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
    }
}
