using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MAUIStudent.Models;

namespace MAUIStudent.ViewModel
{
    internal class AbsenceViewModel
    {
        public ObservableCollection<StudentModel> Students { get; set; }

        public AbsenceViewModel(INavigation navigation)
        {
           
            // Ajouter un enregistrement à la base de données
            AddSampleItem();
        }

        private void AddSampleItem()
        {
            // Créer un nouvel objet FiliereModel à ajouter à la base de données
            var newFiliere = new FiliereModel
            {
                FiliereName = "Informatique"
            };

            // Appeler la méthode d'insertion de la base de données
            App.Database.SaveFiliereAsync(newFiliere).Wait();
        }
    }

}
