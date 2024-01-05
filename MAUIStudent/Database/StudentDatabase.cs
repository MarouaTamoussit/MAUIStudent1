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
            database.CreateTableAsync<StudentModel>().Wait();
        }

       

        public Task<int> SaveStudentDataAsync(StudentModel studentData)
        {
            return database.InsertAsync(studentData);
        }
    }
}
    

