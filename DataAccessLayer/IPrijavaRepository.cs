using Core.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IPrijavaRepository : IRepository<Prijava>
    {
        List<Prijava> GetByKandidataId(int kandidataId);
        List<Prijava> GetByOglasId(int oglasId);
    }
}