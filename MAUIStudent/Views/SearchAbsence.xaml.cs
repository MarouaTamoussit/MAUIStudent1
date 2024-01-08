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
            // R�cup�rer les informations n�cessaires
            string lessonName = Picker2.SelectedItem as string;

            // Appeler la m�thode pour ajouter ou mettre � jour l'absence
            await AddOrUpdateAbsence(fullName, lessonName, e.Value);
        }
    }

    private async Task AddOrUpdateAbsence(string fullName, string lessonName, bool isAbsent)
    {
        try
        {
            // R�cup�rer l'ID de le�on � partir du nom de la le�on
            int lessonId = await App.Database1.GetLessonIDFromName(lessonName);

            // Recherche de l'absence correspondante dans la base de donn�es
            AbsenceModel existingAbsence = await App.Database1.GetAbsenceAsync(fullName, lessonId);

            if (existingAbsence != null)
            {
                // Mise � jour de l'�tat d'absence
                existingAbsence.IsAbsent = isAbsent;

                // Enregistrement des modifications dans la base de donn�es
                await App.Database1.SaveAbsenceDataAsync(existingAbsence);

            }
            else
            {
                // Cr�ez l'objet AbsenceModel avec le nom complet
                AbsenceModel newAbsence = new AbsenceModel
                {
                    CIN = fullName,
                    LessonID = lessonId,
                    IsAbsent = isAbsent
                };

                // Ajoutez l'absence � la base de donn�es
                await App.Database1.SaveAbsenceDataAsync(newAbsence);
            }
        }
        catch (Exception ex)
        {
            // G�rer les exceptions appropri�es
            Console.WriteLine($"Erreur lors de l'ajout ou de la mise � jour de l'absence : {ex.Message}");
        }
    }




}