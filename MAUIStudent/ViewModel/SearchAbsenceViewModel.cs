using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.ViewModel
{
    internal class SearchAbsenceViewModel
    {
        // ...
        public List<string> FiliereOptions { get; set; }
        // ...

        public SearchAbsenceViewModel()
        {
            // Initialisez votre liste d'options (peut être vide au départ)
            FiliereOptions = new List<string>();
            // Appelez une méthode pour remplir les options depuis la base de données
            FetchFiliereOptionsFromDatabase();
        }

        private async void FetchFiliereOptionsFromDatabase()
        {
            // Appel asynchrone pour obtenir les noms de filières
            List<string> filiereNames = await App.Database1.GetFiliereNamesFromDatabase();

            // Assurez-vous que FiliereOptions est initialisé en tant que ObservableCollection<string>
            FiliereOptions.Clear();

            // Ajoutez les noms de filières à FiliereOptions
            foreach (var name in filiereNames)
            {
                FiliereOptions.Add(name);
            }
        }

    }
}
