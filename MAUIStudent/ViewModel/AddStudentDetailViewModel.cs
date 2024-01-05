using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIStudent.Models;
using MAUIStudent.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIStudent.ViewModel
{
    public class AddStudentDetailModel
    {
        private string _CIN, _FirstName, _LastName, _tel, _Email, _filiere;

        public string CIN { get => _CIN; set => _CIN = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string tel { get => _tel; set => _tel = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string filiere { get => _filiere; set => _filiere = value; }

        public ICommand AddCommand { private set; get; }



        private INavigation Navigation;

        public AddStudentDetailModel(INavigation navigation)
        {
            AddCommand = new Command(OnAddCommand);
            Navigation = navigation;
        }




        private void OnAddCommand(object obj)
        {
            StudentModel lm = new StudentModel();
            lm.CIN = CIN;
            lm.FirstName = FirstName;
            lm.LastName = LastName;
            lm.Email = Email;
            lm.tel = tel;
            lm.filiere = filiere;
            App.Database1.SaveStudentDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Etudiant Ajouté", "Ok");
        }
    }
}
