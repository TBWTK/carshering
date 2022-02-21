using System;
using carshering.Core;
using System.Windows.Controls;


namespace carshering.MVVM.ViewModel
{
    class AccountViewModel : ObservableObjects
    {
        public RelayCommand DownloadImage { get; set; }

        public AccountViewModel()
        {
            Image = new Image();

            DownloadImage = new RelayCommand(o =>
            {
                System.Windows.Media.Imaging.BitmapImage myBitmapImage = new System.Windows.Media.Imaging.BitmapImage();
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

    }
}
