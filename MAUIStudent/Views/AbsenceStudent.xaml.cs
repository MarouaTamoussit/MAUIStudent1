using MAUIStudent.Models;
using MAUIStudent.ViewModel;

namespace MAUIStudent.Views;

public partial class AbsenceStudent : ContentPage
{
	public AbsenceStudent()
	{
		InitializeComponent();
        FilierePicker();
        LessonPicker();
        studentsListView.ItemSelected += OnStudentSelected;
        this.BindingContext = new InformationViewModel(this.Navigation);
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

        // Filtrer les �tudiants par fili�re si une fili�re est s�lectionn�e
        if (!string.IsNullOrEmpty(filiereName))
        {
            students = students.Where(s => s.FiliereName == filiereName).ToList();
        }

        // Utilisez une liste de cha�nes pour les noms complets des �tudiants
        List<string> studentsFullNames = students.Select(s => $"{s.FirstName} {s.LastName}").ToList();

        studentsListView.ItemsSource = studentsFullNames;
    }
    private void OnStudentSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            string selectedStudent = e.SelectedItem as string;
            // Utilisez selectedStudent comme requis
        }
    }

    private async void OnCheckBoxChecked(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) 
        {
            // R�cup�rer les informations n�cessaires
            
            string selectedStudent = studentsListView.SelectedItem as string;
            await((ContentPage)App.Current.MainPage).DisplayAlert("Succ�s", $"�tudiant s�lectionn� : {selectedStudent}", "OK");
            string selectedLesson = lessonPicker.SelectedItem as string;

            // Appeler la m�thode pour ajouter l'absence
            AddAbsence(selectedStudent, selectedLesson);
        }
    }
    private async void AddAbsence(string studentName, string lessonName)
    {
        
       //string cin = await App.Database1.GetCINFromStudentName(studentName);
int lessonId = await App.Database1.GetLessonIDFromName(lessonName);

        // Cr�ez l'objet AbsenceModel
        AbsenceModel absence = new AbsenceModel
        {
            CIN = studentName,
            LessonID = lessonId,
            IsAbsent = true // La case est coch�e, donc l'�tudiant est absent
        };

        // Ajoutez l'absence � la base de donn�es
        App.Database1.SaveAbsenceDataAsync(absence);
    }

    /*protected override void OnAppearing()
        {
            base.OnAppearing();

            // R�cup�rer le texte du label avec le nom "label"
            string labelText = label.Text;

            // Utiliser la valeur r�cup�r�e comme vous le souhaitez
            // ...
        }*/

}