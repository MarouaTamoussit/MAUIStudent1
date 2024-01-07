using MAUIStudent.Models;
using MAUIStudent.ViewModel;

namespace MAUIStudent.Views;

public partial class SearchAbsence : ContentPage
{
    private List<string> filieresList;
    private List<string> optionsList;
    private List<string> studentsList;

   
        public SearchAbsence()
        {
            InitializeComponent();
            FilierePicker();
            StudentPicker();
        }

      
    // Assurez-vous d'appeler cette méthode au bon endroit, par exemple dans le constructeur ou OnAppearing
    private async void FilierePicker()
    {
        // Attendre la tâche pour obtenir la liste des noms de filières
        List<string> filieres = await App.Database1.GetFiliereNamesFromDatabase();

        // Ajouter les options de filière au Picker
        foreach (var filiere in filieres)
        {
            Picker1.Items.Add(filiere);
        }
    }
    private async void StudentPicker()
    {
        // Attendre la tâche pour obtenir la liste des étudiants
        List<string> students = await App.Database1.GetStudentsAsync();

        // Ajouter les noms des étudiants au Picker
        foreach (var student in students)
        {
            Picker3.Items.Add(student);
        }
    }
    private async void LessonPicker()
    {
        // Attendre la tâche pour obtenir la liste des étudiants
        List<string> lessons = await App.Database1.GetLessonFromDatabase();

        // Ajouter les noms des étudiants au Picker
        foreach (var lesson in lessons)
        {
            Picker2.Items.Add(lesson);
        }
    }




}