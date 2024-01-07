using MAUIStudent.Models;
using MAUIStudent.ViewModel;

namespace MAUIStudent.Views;

public partial class SearchAbsence : ContentPage
{
    private List<string> FilieresList;
    private List<string> LessonList;
    private List<string> StudentsList;

        public SearchAbsence()
        {
            InitializeComponent();
            FilierePicker();
            LessonPicker();
            StudentPicker();
        }

      
    private async void FilierePicker()
    {
        List<string> filieres = await App.Database1.GetFiliereNamesFromDatabase();

        foreach (var filiere in filieres)
        {
            Picker1.Items.Add(filiere);
        }
    }
    private async void StudentPicker()
    {
        List<string> students = await App.Database1.GetStudentsAsync();

        foreach (var student in students)
        {
            Picker3.Items.Add(student);
        }
    }
    private async void LessonPicker()
    {
        List<string> lessons = await App.Database1.GetLessonFromDatabase();

        foreach (var lesson in lessons)
        {
            Picker2.Items.Add(lesson);
        }
    }




}