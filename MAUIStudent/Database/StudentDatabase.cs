using MAUIStudent.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAUIStudent.Database
{
    public class StudentDatabase
    {
        readonly SQLiteAsyncConnection database;

        public StudentDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LoginModel>().Wait();
            var filiereModelInstance = new FiliereModel();
            database.CreateTableAsync(filiereModelInstance.GetType()).Wait(); 
            database.CreateTableAsync<StudentModel>().Wait();
            database.CreateTableAsync<LessonModel>().Wait();
            
            database.CreateTableAsync<AbsenceModel>().Wait();
        }

        public Task<List<StudentModel>> GetStudentsAsync()
        {
            return database.Table<StudentModel>().ToListAsync();
        }

        public Task<StudentModel> GetStudentAsync(string cin)
        {
            return database.Table<StudentModel>().Where(i => i.CIN == cin).FirstOrDefaultAsync();
        }

        public Task<int> SaveStudentDataAsync(StudentModel studentData)
        {
            if (string.IsNullOrEmpty(studentData.CIN))
            {
                return database.InsertAsync(studentData);
            }
            else
            {
                return database.UpdateAsync(studentData);
            }
        }

        public Task<int> DeleteStudentAsync(StudentModel studentData)
        {
            return database.DeleteAsync(studentData);
        }
        public Task<LoginModel> GetLoginDataAsync(string userName)
        {
            return database.Table<LoginModel>()
                            .Where(i => i.UserName == userName)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLoginDataAsync(LoginModel loginData)
        {
            return database.InsertAsync(loginData);
        }
        public Task<FiliereModel> GetFiliereAsync(string filiereName)
        {
            return database.Table<FiliereModel>()
                            .Where(i => i.FiliereName == filiereName)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFiliereAsync(FiliereModel filiereData)
        {
            return database.InsertAsync(filiereData);
        }
    }
}
