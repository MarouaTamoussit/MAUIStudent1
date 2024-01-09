namespace MAUIStudent.Views;

public partial class InformationPage : ContentPage
{
	public InformationPage()
	{
		InitializeComponent();
        StudentPicker();
    }
    private async void StudentPicker()
       {
           List<string> students = await App.Database1.GetStudentsAsync();

           foreach (var student in students)
           {
               Picker3.Items.Add(student);
           }
       
    }
    private void OnInformationSelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedInformation = Picker3.SelectedItem as string;
        LoadInformationStudents(selectedInformation);
    }
    private  async void LoadInformationStudents(string selectedStudent)
    {
        List<string> absentStudents = await App.Database1.GetCINFromAbsentName(selectedStudent);
        abscence.Text = absentStudents.Count.ToString();
        List<string> presents = await App.Database1.GetLessonFromDatabase(); 
           int  x = presents.Count - absentStudents.Count ;
        presence.Text = x.ToString();

    }

}