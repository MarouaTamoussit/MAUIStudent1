using MAUIStudent.ViewModel;

namespace MAUIStudent.Views;

public partial class AddLessonPage : ContentPage
{
	public AddLessonPage()
	{
		InitializeComponent();
        this.BindingContext = new AddLessonDetailModel(this.Navigation);

    }
}