using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.Models
{
    internal class AbsenceModel
    {
        [PrimaryKey, AutoIncrement]
        public int AbsenceId { get; set; }

        [ForeignKey("StudID")]
        public string CIN { get; set; }
        public StudentModel StudID{ get; set; }

        [ForeignKey("lessID")]
        public int LessonId { get; set; }
        public LessonModel lessID { get; set; }       

        public bool IsAbsent { get; set; }= false;
    }
}
