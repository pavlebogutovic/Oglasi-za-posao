using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Prijava
    {
        public int IdPrijave { get; set; }
        public DateTime DatumPrijave { get; set; }
        public string? StatusPrijave { get; set; }
        public string? KomentarNaPrijavi { get; set; }
        public int IdKorisnika { get; set; }
        public int IdOglasa { get; set; }
    }
}

