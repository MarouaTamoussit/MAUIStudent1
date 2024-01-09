using MAUIStudent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIStudent.ViewModel
{
    public class SearchAbsenceViewModel
    {
        public ICommand CancelCommand { private set; get; }

        private INavigation Navigation;
        public SearchAbsenceViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CancelCommand = new Command(OnCancelCommand);

        }

        private async void OnCancelCommand(object obj)
        {
            await Navigation.PushModalAsync(new AccueilPage());
        }
    }
}
