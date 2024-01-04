using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIStudent.Models
{
    public class Prof
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String username { get; set; }

        public String password { get; set; }


    }
}
