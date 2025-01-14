using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Oglas
    {
        public int IdOglasa { get; set; }
        public string? NazivPozicije { get; set; }
        public string? OpisPosla { get; set; }
        public DateTime DatumObjaveOglasa { get; set; }
        public DateTime DatumIstekaOglasa { get; set; }
        public decimal Plata { get; set; }
        public string? StatusOglasa { get; set; }
        public int IdPoslodavca { get; set; }
        public int IdKategorijaPosla { get; set; }
    }
}
