using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MAUIStudent.Models
{
    

    public class FiliereModel
    {
        [PrimaryKey, AutoIncrement]
        public string FiliereId { get; set; }

        public string FiliereName { get; set; }
    }

}
