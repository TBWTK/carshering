using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carshering.MVVM.ViewModel
{
    // Класс для примера реализации, не имеет дальнешей реализации и будет удален при подключении базы данных
    class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class RegistrationViewModel
    {
        public List<Gender> Genders { get; set; }

        public RegistrationViewModel()
        {
            Genders = new List<Gender>()
            {
                new Gender(){ Id = 1, Name = "мужской"},
                new Gender(){ Id = 2, Name = "женский" }
            };
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
            }
        }
    }
}
