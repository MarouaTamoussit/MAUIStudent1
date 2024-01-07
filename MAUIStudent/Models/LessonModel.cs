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

        public string Prof { get; set; }

        public string FiliereName { get; set; }

    }
}