using Core.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOglasRepository : IRepository<Oglas>
    {
        List<Oglas> GetByPoslodavacId(int poslodavacId);
        List<Oglas> GetByKategorijaId(int kategorijaId);
    }
}
