using Core.Result;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOglasBusiness
    {
        ResultWrapper AddOglas(Oglas oglas);
        ResultWrapper RemoveOglas(Oglas oglas);
        ResultWrapper UpdateOglas(Oglas oglas);
        ResultWrapper GetOglasById(int id);
        List<Oglas> GetOglasByPoslodavacId(int id); // Svi oglasi odredjenog poslodavca
        List<Oglas> GetAllOglasi();
    }
}
