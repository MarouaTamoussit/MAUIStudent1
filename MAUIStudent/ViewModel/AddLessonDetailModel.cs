using MAUIStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIStudent.ViewModel
{
   
    public class AddLessonDetailModel
    {
        private string _LessonName, _prof, _FilierName;
        public string LessonName { get => _LessonName; set => _LessonName = value; }
        public string prof { get => _prof; set => _prof = value; }
        public string FilierName { get => _FilierName; set => _FilierName = value; }

        public ICommand AddLessonCommand { private set; get; }

        private INavigation Navigation;
        public AddLessonDetailModel(INavigation navigation)
        {
            AddLessonCommand = new Command(OnAddLessonCommand);
            Navigation = navigation;
        }
        private void OnAddLessonCommand(object obj)
        {
            LessonModel lm = new LessonModel();
            
            lm.LessonName = LessonName;
            lm.Prof = prof;
            lm.FiliereName = FilierName;
            
            App.Database1.SaveLessonDataAsync(lm);
            App.Current.MainPage.DisplayAlert("Success", "Lesson Ajouté", "Ok");
        }
    }
}
