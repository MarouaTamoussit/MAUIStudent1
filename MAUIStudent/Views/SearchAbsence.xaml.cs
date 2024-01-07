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

      
    // Assurez-vous d'appeler cette m�thode au bon endroit, par exemple dans le constructeur ou OnAppearing
    private async void FilierePicker()
    {
        // Attendre la t�che pour obtenir la liste des noms de fili�res
        List<string> filieres = await App.Database1.GetFiliereNamesFromDatabase();

        // Ajouter les options de fili�re au Picker
        foreach (var filiere in filieres)
        {
            Picker1.Items.Add(filiere);
        }
    }
    private async void StudentPicker()
    {
        // Attendre la t�che pour obtenir la liste des �tudiants
        List<string> students = await App.Database1.GetStudentsAsync();

        // Ajouter les noms des �tudiants au Picker
        foreach (var student in students)
        {
            Picker3.Items.Add(student);
        }
    }
    private async void LessonPicker()
    {
        // Attendre la t�che pour obtenir la liste des �tudiants
        List<string> lessons = await App.Database1.GetLessonFromDatabase();

        // Ajouter les noms des �tudiants au Picker
        foreach (var lesson in lessons)
        {
            Picker2.Items.Add(lesson);
        }
    }




}