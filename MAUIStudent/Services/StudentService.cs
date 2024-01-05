using MAUIStudent.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MAUIStudent.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }

        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(studentModel);
        }

    }
}
