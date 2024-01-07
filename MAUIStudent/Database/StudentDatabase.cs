using MAUIStudent.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            database.CreateTableAsync<FiliereModel>().Wait();
            database.CreateTableAsync<StudentModel>().Wait();
            database.CreateTableAsync<LessonModel>().Wait();

            database.CreateTableAsync<AbsenceModel>().Wait();
        }

       

        public Task<StudentModel> GetStudentAsync(string cin)
        {
            return database.Table<StudentModel>().Where(i => i.CIN == cin).FirstOrDefaultAsync();
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
        public Task<List<string>> GetFiliereNamesFromDatabase()
        {
            return database.Table<FiliereModel>()
                            .ToListAsync()
                            .ContinueWith(t => t.Result.Select(f => f.FiliereName).ToList());
        }

        public Task<List<string>> GetStudentsAsync()
        {
            return database.Table<StudentModel>()
                            .ToListAsync()
                            .ContinueWith(t => t.Result.Select(f => f.FirstName).ToList());
        }

        public Task<List<string>> GetLessonFromDatabase()
        {
            return database.Table<LessonModel>()
                            .ToListAsync()
                            .ContinueWith(t => t.Result.Select(f => f.LessonName).ToList());
        }

        public Task<int> SaveStudentDataAsync(StudentModel student)
        {
            return database.InsertAsync(student);
        }
        
        public Task<int> SaveLessonDataAsync(LessonModel l)
        {

            return database.InsertAsync(l);

        }
        public Task<int> SaveFiliereDataAsync(FiliereModel f)
        {
            return database.InsertAsync(f);

        }
        /* public Task<List<StudentModel>> GetStudentsAsync()
         {
             return _database.Table<StudentModel>().ToListAsync();
         }
         public Task<int> SaveStudentDataAsync(StudentModel studentData)
          {
              return database.InsertAsync(studentData);
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
          }*/
    }
}
    

