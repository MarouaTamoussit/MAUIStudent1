using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.ViewModel
{
    public class SearchAbsenceViewModel
    {
        public List<string> FiliereOptions { get; set; }
        public List<string> LessonOptions { get; set; }

        public SearchAbsenceViewModel()
        {
            FiliereOptions = new List<string>();
            FetchFiliereOptionsFromDatabase();
            LessonOptions = new List<string>();
            FetchLessonOptionsFromDatabase();

        }

        private async void FetchFiliereOptionsFromDatabase()
        {
            List<string> filiereNames = await App.Database1.GetFiliereNamesFromDatabase();

            FiliereOptions.Clear();

            foreach (var name in filiereNames)
            {
                FiliereOptions.Add(name);
            }
        }
        private async void FetchLessonOptionsFromDatabase()
        {
            List<string> lessons = await App.Database1.GetLessonFromDatabase();

            LessonOptions.Clear();

            foreach (var lesson in lessons)
            {
                LessonOptions.Add(lesson);
            }
        }

    }
}
