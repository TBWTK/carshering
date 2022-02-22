using System;
using carshering.Core;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace carshering.MVVM.ViewModel
{
    class AccountViewModel : ObservableObjects
    {
        public RelayCommand DownloadImage { get; set; }
        public RelayCommand CreateUser { get; set; }


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
            CreateUser = new RelayCommand(o =>
            {
                try
                {
                    //User users = new User() { name = _Name, password = _Password, gender = NodeCategoryGender.Id, image = getJPGFromImageControl(image.Source as BitmapImage) };
                    //db.User.Add(users);
                    //db.SaveChanges();
                }
                catch
                {
                    System.Windows.MessageBox.Show("ERROR");
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
        
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArray)
        {
            Image image = new Image();
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                image.Source = BitmapFrame.Create(stream,
                                                  BitmapCreateOptions.None,
                                                  BitmapCacheOption.OnLoad);
            }
            return image;
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


//пример выгрузки из бд
//var UU = db.User.Join(db.gender, u => u.Id, c => c.Id, (u, c) => new
//{
//    Name = u.name,
//    Password = u.password,
//    img = u.image,
//    Gender = c.name
//}).Where(u => u.Name == "234").ToList();

//Genders = db.gender.ToList();
////var que = db.User.ToList();
//foreach (var user in UU)
//{
//    Name = user.Name;
//    Password = user.Password;
//    image = byteArrayToImage(user.img);
//    Gender = Convert.ToString(user.Gender);
//}