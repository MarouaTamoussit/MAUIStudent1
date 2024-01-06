using MAUIStudent.Database;
using MAUIStudent.Views;
using MAUIStudent;

namespace MAUIStudent
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
        static StudentDatabase database;
        

        public static StudentDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new StudentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
                }
                return database;
            }
        }
    }
}
