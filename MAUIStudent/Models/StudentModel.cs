using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("FiliereModel")]
        public string FiliereId { get; set; }
        public FiliereModel FiliereModel { get; set; }

    }
}
