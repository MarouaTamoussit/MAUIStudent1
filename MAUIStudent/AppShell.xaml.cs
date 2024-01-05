using MAUIStudent.Views;

namespace MAUIStudent
{
    public partial class AppShell : Shell
    {
   
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddStudentDetail), typeof(AddStudentDetail));

        }
    }
}
