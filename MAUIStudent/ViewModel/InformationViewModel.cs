using MAUIStudent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIStudent.ViewModel
{
    public class InformationViewModel
    {
        public List<string> InformationOptions { get; set; }
        public ICommand SaveCommand { private set; get; }
        private INavigation Navigation;
        public InformationViewModel(INavigation navigation)
        {
            InformationOptions = new List<string>();
            Navigation = navigation;
            SaveCommand = new Command(OnInfoCommand);


        }

        private async void OnInfoCommand(object obj)
        {
            await Navigation.PushModalAsync(new InformationPage());
        }
    }
}
