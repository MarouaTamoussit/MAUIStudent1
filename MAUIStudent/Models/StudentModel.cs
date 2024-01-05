using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.Models
{
    public class StudentModel
    {
        [PrimaryKey]
        public string CIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string tel { get; set; }
        public string filiere { get; set; }

    }
}
