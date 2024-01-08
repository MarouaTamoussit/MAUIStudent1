using MAUIStudent.Models;

namespace MAUIStudent.Views;

public partial class AbsenceStudent : ContentPage
{
	public AbsenceStudent()
	{
		InitializeComponent();
        FilierePicker();
        LessonPicker();
}
    private async void FilierePicker()
    {
        List<string> filieres = await App.Database1.GetFiliereNamesFromDatabase();

        foreach (var filiere in filieres)
        {
            filierePicker.Items.Add(filiere);
        }
    }
    private async void LessonPicker()
    {
        List<string> LessonOptions = await App.Database1.GetLessonFromDatabase();
        foreach (var lesson in LessonOptions)
        {
            lessonPicker.Items.Add(lesson);
        }
    }
    private async void OnFiliereSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedFiliere = filierePicker.SelectedItem as string;

        if (!string.IsNullOrEmpty(selectedFiliere))
        {
            await LoadStudentsAsync(selectedFiliere);
        }
    }

    /* private async Task LoadStudentsAsync(string filiereName)
     {
         List<string> StudentsList = await App.Database1.GetStudentsAsync(filiereName);

         studentsListView.ItemsSource = StudentsList;
     }*/
    private async Task LoadStudentsAsync(string filiereName)
    {
        List<StudentModel> students = await App.Database1.GetStudentsAsync(filiereName);

        // Filtrer les étudiants par filière si une filière est sélectionnée
        if (!string.IsNullOrEmpty(filiereName))
        {
            students = students.Where(s => s.FiliereName == filiereName).ToList();
        }

        // Utilisez une liste de chaînes pour les noms complets des étudiants
        List<string> studentsFullNames = students.Select(s => $"{s.FirstName} {s.LastName}").ToList();

        studentsListView.ItemsSource = studentsFullNames;
    }

    private void OnCheckBoxChecked(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) 
        {
            // Récupérer les informations nécessaires
            string selectedStudent = studentsListView.SelectedItem as string;
            string selectedLesson = lessonPicker.SelectedItem as string;

            // Appeler la méthode pour ajouter l'absence
            AddAbsence(selectedStudent, selectedLesson);
        }
    }
    private async void AddAbsence(string studentName, string lessonName)
    {

        int lessonId = await App.Database1.GetLessonIDFromName(lessonName);

        // Créez l'objet AbsenceModel
        AbsenceModel absence = new AbsenceModel
        {
            CIN = studentName,
            LessonID = lessonId,
            IsAbsent = true // La case est cochée, donc l'étudiant est absent
        };

        // Ajoutez l'absence à la base de données
        App.Database1.SaveAbsenceDataAsync(absence);
    }


}