using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Korisnik
    {
        public int IdKorisnika { get; set; }
        public string? NazivKorisnika { get; set; }
        public string? EmailKorisnika { get; set; }
        public string? LozinkaKorisnika { get; set; }
        public string? TipKorisnika { get; set; }
        public string? OpisKorisnika { get; set; }
        public string? VestineKorisnika { get; set; }
        public DateTime DatumRegistracije { get; set; }
    }
}