using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_Filmova2
{
    class Producent : Film
    {
        public string p_name { get; set; }
        public string p_surname { get; set; }
        public int age { get; set; }
        public string BirthPlace { get; set; }
        public string Description { get; set; }
    }
}
