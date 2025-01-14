using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Result;
using Entities;
using Entities.DTO;

namespace BusinessLayer.Abstract
{
    internal interface IKorisnikBusiness
    {
        ResultWrapper Login(LoginDTO loginDTO);
        ResultWrapper Add(Korisnik korisnik); // Dodata registracija korisnika
        ResultWrapper Update(Korisnik korisnik);
        ResultWrapper Delete(Korisnik korisnik);
        List<Korisnik> GetKorisnici();

        Korisnik GetById(int id);
        //List<Korisnik> GetKorisnikByType(string korisnikType); // Dohvatanje korisnika prema tipu (kandidat/poslodavac)
    }
}
