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
        static LoginDatabase database;
        static StudentDatabase database1;
        // Create the database connection as a singleton.
        public static LoginDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
                }
                return database;
            }
        }

        public static StudentDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new StudentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
                }
                return database1;
            }
        }
    }
}
