using MAUIStudent.ViewModel;

namespace MAUIStudent.Views
{

	

	public partial class AddStudentDetail : ContentPage
	{

		public AddStudentDetail()
        {
			InitializeComponent();
            this.BindingContext = new AddStudentDetailModel(this.Navigation);


        }
    }
}