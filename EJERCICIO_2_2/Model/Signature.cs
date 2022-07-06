using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EJERCICIO_2_2.Model
{
    public class Signature
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }   

    }
}
