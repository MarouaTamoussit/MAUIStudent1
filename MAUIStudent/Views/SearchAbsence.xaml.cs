using MAUIStudent.Models;
using MAUIStudent.ViewModel;

namespace MAUIStudent.Views;

public partial class SearchAbsence : ContentPage
{

        public SearchAbsence()
        {
            InitializeComponent();
            FilierePicker();
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
    private async void OnCheckBoxChecked(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is string fullName)
        {
            // Récupérer les informations nécessaires
            string lessonName = Picker2.SelectedItem as string;

            // Appeler la méthode pour ajouter ou mettre à jour l'absence
            await AddOrUpdateAbsence(fullName, lessonName, e.Value);
        }
    }

    private async Task AddOrUpdateAbsence(string fullName, string lessonName, bool isAbsent)
    {
        try
        {
            // Récupérer l'ID de leçon à partir du nom de la leçon
            int lessonId = await App.Database1.GetLessonIDFromName(lessonName);

            // Recherche de l'absence correspondante dans la base de données
            AbsenceModel existingAbsence = await App.Database1.GetAbsenceAsync(fullName, lessonId);

            if (existingAbsence != null)
            {
                // Mise à jour de l'état d'absence
                existingAbsence.IsAbsent = isAbsent;

                // Enregistrement des modifications dans la base de données
                await App.Database1.SaveAbsenceDataAsync(existingAbsence);

            }
            else
            {
                // Créez l'objet AbsenceModel avec le nom complet
                AbsenceModel newAbsence = new AbsenceModel
                {
                    CIN = fullName,
                    LessonID = lessonId,
                    IsAbsent = isAbsent
                };

                // Ajoutez l'absence à la base de données
                await App.Database1.SaveAbsenceDataAsync(newAbsence);
            }
        }
        catch (Exception ex)
        {
            // Gérer les exceptions appropriées
            Console.WriteLine($"Erreur lors de l'ajout ou de la mise à jour de l'absence : {ex.Message}");
        }
    }




}