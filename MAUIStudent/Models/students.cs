using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace MAUIStudent.Models
{
    public class Students
    {
        [PrimaryKey]
        public String CIN { get; set; }
        public String nom { get; set; }

        public String prenom { get; set; }

        public String email { get; set; }

        public String tel { get; set; }

        public String Filiere { get; set; }


    }
}