using Core.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IKorisnikRepository : IRepository<Korisnik>
    {
        Korisnik GetByEmail(string email);
    }
}

