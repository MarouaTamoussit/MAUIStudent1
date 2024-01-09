using MAUIStudent.Models;
using MAUIStudent.ViewModel;

namespace MAUIStudent.Views;

public partial class SearchAbsence : ContentPage
{

        public SearchAbsence()
        {
            InitializeComponent();
            FilierePicker();
        this.BindingContext = new SearchAbsenceViewModel(this.Navigation);

        absentsListView.ItemSelected += OnStudentSelected;

        // LessonPicker();
        //StudentPicker();

        //Picker1.SelectedIndexChanged += OnFiliereSelectedIndexChanged;

    }


    private async void FilierePicker()
    {
        List<string> filieres = await App.Database1.GetFiliereNamesFromDatabase();

        foreach (var filiere in filieres)
        {
            Picker1.Items.Add(filiere);
        }
    }
    /*private async void StudentPicker()
    {
        List<string> students = await App.Database1.GetStudentsAsync();

        foreach (var student in students)
        {
            Picker3.Items.Add(student);
        }
    }*/
    private async void LessonPicker()
    {
        Picker2.Items.Clear();
        List<string> LessonOptions = await App.Database1.GetLessonFromDatabase();
        foreach (var lesson in LessonOptions)
            {
                Picker2.Items.Add(lesson);
            }
    }
    private async void OnFiliereSelectedIndexChanged(object sender, EventArgs e)
    {
        LessonPicker();
    }


    private void OnLessonSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedLesson = Picker2.SelectedItem as string;
        LoadAbsentStudents(selectedLesson);
        
    }

    private async void LoadAbsentStudents(string lessonName)
    {
        List<string> absentStudents = await App.Database1.GetAbsentStudentsAsync(lessonName);
        //List<string> absentStudent = new List<string>{ "a", "b", "c" };
       // List<string> absentStudent = await App.Database1.GetCINsFromAbsencesAsync();


        absentsListView.ItemsSource = absentStudents;
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
        if (absentsListView.SelectedItem != null)
        {
            string selectedStudent = absentsListView.SelectedItem as string;
            string lessonName = Picker2.SelectedItem as string;

           // await AddOrUpdateAbsence(selectedStudent, lessonName, e.Value);

            await DisplayAlert("Succès", $"Étudiant sélectionné : {selectedStudent}", "OK");

            // Supprimer l'étudiant de la table si la case est désélectionnée
            if (!e.Value)
            {
                await RemoveStudentFromAbsences(selectedStudent, lessonName);
            }
        }
    }

    private async Task RemoveStudentFromAbsences(string fullName, string lessonName)
    {
        try
        {
            int lessonId = await App.Database1.GetLessonIDFromName(lessonName);

            // Recherche de l'absence correspondante dans la base de données
            AbsenceModel existingAbsence = await App.Database1.GetAbsenceAsync(fullName, lessonId);

            if (existingAbsence != null)
            {
                // Supprimer l'absence de la base de données
                int rowsAffected = await App.Database1.DeleteAbsenceAsync(existingAbsence);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Suppression réussie");
                }
                else
                {
                    Console.WriteLine("Aucune suppression effectuée");
                }
            }
        }
        catch (Exception ex)
        {
            // Gérer les exceptions appropriées
            Console.WriteLine($"Erreur lors de la suppression de l'absence : {ex.Message}");
        }
    }


}