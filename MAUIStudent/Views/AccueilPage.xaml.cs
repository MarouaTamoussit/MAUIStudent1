using MAUIStudent.Views;
using MAUIStudent.Models;
using MAUIStudent.ViewModel;
namespace MAUIStudent.Views;

public partial class AccueilPage : ContentPage
{
   
    public AccueilPage()
	{
		InitializeComponent();
        this.BindingContext = new AccueilViewModel(this.Navigation);

    }
 



}