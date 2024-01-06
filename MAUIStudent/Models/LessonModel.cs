using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.Models
{
    public class LessonModel
    {
       [PrimaryKey, AutoIncrement]
        public int LessonId { get; set; }
        public string LessonName { get; set; }

        // foreign key
        [ForeignKey("prof")]
        public string UserName { get; set; }
        public LoginModel prof { get; set; }
      
        [ForeignKey("FilId")]
        public int FiliereId { get; set; }
        public FiliereModel FilId { get; set; }

    }
}
