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

       

       /*public Task<StudentModel> GetStudentAsync(string cin)
        {
            return database.Table<StudentModel>().Where(i => i.CIN == cin).FirstOrDefaultAsync();
        }*/

       

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

       /* public Task<FiliereModel> GetFiliereAsync(string filiereName)
        {
            return database.Table<FiliereModel>()
                            .Where(i => i.FiliereName == filiereName)
                            .FirstOrDefaultAsync();
        }*/

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
                            .ContinueWith(t => t.Result.Select(f => f.FirstName + " " + f.LastName).ToList());
        }

        public Task<List<StudentModel>> GetStudentsAsync(string filiereName)
        {
            return database.Table<StudentModel>()
                            .Where(student => student.FiliereName == filiereName)
                            .ToListAsync();
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
        public Task<List<string>> GetLessonsByFiliereFromDatabase(string filiereName)
        {
            return database.Table<LessonModel>()
                            .Where(lesson => lesson.FiliereName == filiereName)
                            .ToListAsync()
                            .ContinueWith(t => t.Result.Select(lesson => lesson.LessonName).ToList());
        }
        public async Task<string> GetCINFromStudentName(string studentName)
        {
            try
            {
                var student = await database.Table<StudentModel>()
                                           .Where(s => $"{s.FirstName} {s.LastName}" == studentName)
                                           .FirstOrDefaultAsync();

                return student?.CIN ?? string.Empty;
            }
            catch (Exception ex)
            {
                // Gérer les exceptions appropriées
                Console.WriteLine($"Erreur lors de la récupération du CIN : {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<List<string>> GetCINFromAbsentName(string studentName)
        {
            try
            {
                // Récupérez l'ID de la leçon en fonction de son nom
                String Cin = await GetCINFromStudentName(studentName);

                // Récupérez les CIN des étudiants absents p
                var absentCINs = await database.Table<AbsenceModel>()
                    .ToListAsync();

                // Directement retourner la liste de CINs
                return absentCINs.Select(absence => absence.CIN).ToList();
            }
            catch (Exception ex)
            {
                // Gérez les exceptions appropriées
                Console.WriteLine($"Erreur lors de la récupération des CIN des étudiants absents : {ex.Message}");
                return new List<string>();
            }
        }


        public async Task<int> GetLessonIDFromName(string lessonName)
        {
            try
            {
                var lesson = await database.Table<LessonModel>()
                                          .Where(l => l.LessonName == lessonName)
                                          .FirstOrDefaultAsync();

                return lesson?.LessonId ?? 0;
            }
            catch (Exception ex)
            {
                // Gérer les exceptions appropriées
                Console.WriteLine($"Erreur lors de la récupération de l'ID de leçon : {ex.Message}");

                return 0;
            }
        }

        public async Task<int> SaveAbsenceDataAsync(AbsenceModel absence)
        {
            try
            {
                await ((ContentPage)App.Current.MainPage).DisplayAlert("Succès", "Ajout d'absence avec succès", "OK");
                return await database.InsertAsync(absence);


            }
            catch (Exception ex)
            {
                // Gérer les exceptions appropriées
                Console.WriteLine($"Erreur lors de l'enregistrement de l'absence : {ex.Message}");
                await ((ContentPage)App.Current.MainPage).DisplayAlert("Erreur", "Une erreur s'est produite lors de l'ajout de l'absence", "OK");

                return 0;
            }
        }
        public async Task<List<string>> GetAbsentStudentsAsync(string lessonName)
        {
            try
            {
                // Récupérez l'ID de la leçon en fonction de son nom
                int lessonId = await GetLessonIDFromName(lessonName);

                // Récupérez les CIN des étudiants absents pour la leçon donnée
                var absentCINs = await database.Table<AbsenceModel>()
                    .Where(absence => absence.LessonID == lessonId && absence.IsAbsent)
                    .ToListAsync();

                // Directement retourner la liste de CINs
                return absentCINs.Select(absence => absence.CIN).ToList();
            }
            catch (Exception ex)
            {
                // Gérez les exceptions appropriées
                Console.WriteLine($"Erreur lors de la récupération des CIN des étudiants absents : {ex.Message}");
                return new List<string>();
            }
        }



        public Task<List<string>> GetCINsFromAbsencesAsync()
        {
            return database.Table<AbsenceModel>()
                            .ToListAsync()
                            .ContinueWith(t => t.Result.Select(absence => absence.CIN).ToList());
        }

        public async Task<AbsenceModel> GetAbsenceAsync(string fullName, int lessonId)
        {
            try
            {
                return await database.Table<AbsenceModel>()
                                    .Where(a => a.CIN == fullName && a.LessonID == lessonId)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Gérer les exceptions appropriées
                Console.WriteLine($"Erreur lors de la récupération de l'absence : {ex.Message}");
                return null;
            }
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
    

