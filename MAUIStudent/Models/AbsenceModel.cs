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

        public string CIN { get; set; }

        public int LessonID { get; set; }

        public bool IsAbsent { get; set; } = false;
    }
}