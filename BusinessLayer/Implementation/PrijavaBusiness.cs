using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Core.Result;
using DataAccessLayer;
using Entities;

namespace BusinessLayer.Implementation
{
    public class PrijavaBusiness : IPrijavaBusiness
    {
        private readonly IPrijavaRepository prijavaRepository;
        private readonly IOglasRepository oglasRepository;

        public PrijavaBusiness(IPrijavaRepository prijavaRepository, IOglasRepository oglasRepository)
        {
            this.prijavaRepository = prijavaRepository;
            this.oglasRepository = oglasRepository;
        }

        public ResultWrapper AddPrijava(Prijava prijava)
        {
            var oglas = oglasRepository.GetAll().FirstOrDefault(o => o.IdOglasa == prijava.IdOglasa);

            if (oglas == null || oglas.StatusOglasa != "Open")
            {
                return new ResultWrapper
                {
                    Success = false,
                    Message = "Oglas nije otvoren za prijave." // Job listing not open for applications
                };
            }

            if (prijavaRepository.Add(prijava))
            {
                return new ResultWrapper
                {
                    Success = true,
                    Message = "Prijava uspešno kreirana." // Application successfully created
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Greška prilikom kreiranja prijave." // Error while creating application
            };
        }

        public ResultWrapper RemovePrijava(Prijava prijava)
        {
            if (prijavaRepository.Delete(prijava))
            {
                return new ResultWrapper
                {
                    Success = true,
                    Message = "Prijava uspešno obrisana." // Application successfully removed
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Greška prilikom brisanja prijave." // Error while removing application
            };
        }

        public ResultWrapper GetPrijavaById(int id)
        {
            // Use GetAll and filter by ID
            var prijava = prijavaRepository.GetAll().FirstOrDefault(p => p.IdPrijave == id);

            if (prijava != null)
            {
                return new ResultWrapper
                {
                    Success = true,
                    Data = prijava,
                    Message = "Prijava pronađena." // Application found
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Prijava nije pronađena." // Application not found
            };
        }

        public List<Prijava> GetPrijaveByKandidatId(int kandidataId)
        {
            return prijavaRepository.GetByKandidataId(kandidataId);
        }

        public List<Prijava> GetPrijaveByOglasId(int oglasId, int poslodavacId)
        {
            var oglas = oglasRepository.GetAll().FirstOrDefault(o => o.IdOglasa == oglasId);

            if (oglas == null || oglas.IdPoslodavca != poslodavacId)
            {
                return new List<Prijava>();
            }

            return prijavaRepository.GetByOglasId(oglasId);
        }

        public ResultWrapper UpdatePrijava(Prijava prijava)
        {
            if (prijavaRepository.Update(prijava))
            {
                return new ResultWrapper
                {
                    Success = true,
                    Message = "Prijava uspešno ažurirana." // Application successfully updated
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Greška prilikom ažuriranja prijave." // Error while updating application
            };
        }

        public List<Prijava> GetAllPrijave()
        {
            return prijavaRepository.GetAll();
        }
    }
}