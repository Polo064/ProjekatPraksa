using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica_Filmova2
{
    class Film
    {
        public string Name { get; set; }
        public Reziser Director { get; set; }
        public Producent Producer { get; set; }
        public Zanr Genre { get; set; }
        public int DateOfRelease { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public int Price { get; set; }
        public List<string> Actors { get; set; }
        public Film() { }     
        public override string ToString()
        {
            return "Ime: " + Name + "\n"
                    + "Reziser: " + Director.d_name + " " + Director.d_surname + "\n"
                    + "Producent: " + Producer.p_name + " " + Producer.p_surname + "\n"
                    + "Zanr: " + Genre.Name + "\n"
                    + "Godina Izdavanja: " + DateOfRelease + "\n"
                    + "Ocena: " + Rating + "\n"
                    + "Cena: " + Price + " din";
            
        }
        public string ispisiOpis()
        {
            return Description;
        }
    }
}
