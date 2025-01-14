using Core.Result;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPrijavaBusiness
    {
        ResultWrapper AddPrijava(Prijava prijava);
        ResultWrapper RemovePrijava(Prijava prijava);
        ResultWrapper GetPrijavaById(int id);

        List<Prijava> GetPrijaveByKandidatId(int kandidataId); // Prijave odredjenog kandidata
        List<Prijava> GetPrijaveByOglasId(int oglasId, int poslodavacId); // Prijave na odredjeni oglas (samo za poslodavca)
        ResultWrapper UpdatePrijava(Prijava prijava);
        List<Prijava> GetAllPrijave();
    }
}
