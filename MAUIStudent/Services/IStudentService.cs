using MAUIStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.Services
{
  
        public interface IStudentService
        {
      
            Task<int> AddStudent(StudentModel studentModel);
            
       
        }
    
}
