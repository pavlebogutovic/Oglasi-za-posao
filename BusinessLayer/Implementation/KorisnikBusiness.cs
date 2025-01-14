using BusinessLayer.Abstract;
using Core.Bezbednost;
using Core.Result;
using DataAccessLayer;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class KorisnikBusiness : IKorisnikBusiness
    {
        private readonly IKorisnikRepository korisnikRepository;
        private readonly IOglasRepository oglasRepository;

        public KorisnikBusiness(IKorisnikRepository korisnikRepository, IOglasRepository oglasRepository)
        {
            this.korisnikRepository = korisnikRepository;
            this.oglasRepository = oglasRepository;
        }

        public ResultWrapper Add(Korisnik korisnik)
        {

            korisnik.LozinkaKorisnika = HashingHelper.CreateHash(korisnik.LozinkaKorisnika!);
            if (korisnikRepository.Add(korisnik) == true)
            {
                return new ResultWrapper
                {
                    Message = "Korisnički nalog uspešno dodat",
                    Success = true
                };
            }
            else
            {
                return new ResultWrapper
                {
                    Message = "Greška",
                    Success = false
                };
            }
        }

        public ResultWrapper Delete(Korisnik korisnik)
        {
            if (oglasRepository.GetByPoslodavacId(korisnik.IdKorisnika).Count > 0)
            {
                return new ResultWrapper
                {
                    Message = "Korisnicki nalog je povezan sa tabelom Oglas",
                    Success = false
                };
            }
            else
            {
                if (korisnikRepository.Delete(korisnik) == true)
                {
                    return new ResultWrapper
                    {
                        Message = "Uspešno obrisan nalog",
                        Success = true
                    };
                }
                else
                {
                    return new ResultWrapper
                    {
                        Message = "Greska",
                        Success = false
                    };
                }

            }
        }
        public Korisnik GetById(int id)
        {
            var x = korisnikRepository.GetAll().Find(item => item.IdKorisnika == id);
            if (x == null) return new Korisnik();
            return x;
        }

        public List<Korisnik> GetKorisnici()
        {
            return korisnikRepository.GetAll();
        }

        public ResultWrapper Login(LoginDTO loginDTO)
        {
            Korisnik korisnik = korisnikRepository.GetByEmail(loginDTO.Email!);
            if (korisnik == null)
            {
                return new ResultWrapper
                {
                    Success = false,
                    Message = "Ovaj korisnik ne postoji"
                };
            }
            else
            {
                if (HashingHelper.VerifyHash(loginDTO.Password!, korisnik.LozinkaKorisnika!) == true)
                {
                    return new ResultWrapper
                    {
                        Success = true,
                        Message = "Uspešno"
                    };
                }
                else
                {
                    return new ResultWrapper
                    {
                        Success = false,
                        Message = "Pogrešno korisničko ime ili lozinka"
                    };
                }
            }
        }

        public ResultWrapper Update(Korisnik korisnik)
        {
            return korisnikRepository.Update(korisnik) == true ?
                new ResultWrapper
                {
                    Message = "Uspešno",
                    Success = true
                } : new ResultWrapper
                {
                    Message = "Greska",
                    Success = false
                };
        }
    }
}
