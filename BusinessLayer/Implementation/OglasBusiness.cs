using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Core.Result;
using DataAccessLayer;
using Entities;
using BusinessLayer.Abstract;
using Core.Result;
using DataAccessLayer;

namespace BusinessLayer.Implementation
{
    public class OglasBusiness : IOglasBusiness
    {
        private readonly IOglasRepository oglasRepository;

        public OglasBusiness(IOglasRepository oglasRepository)
        {
            this.oglasRepository = oglasRepository;
        }

        public ResultWrapper AddOglas(Oglas oglas)
        {
            if (oglasRepository.Add(oglas))
            {
                return new ResultWrapper
                {
                    Success = true,
                    Message = "Oglas uspešno dodat." // Job listing successfully added
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Greška prilikom dodavanja oglasa." // Error while adding the job listing
            };
        }

        public ResultWrapper RemoveOglas(Oglas oglas)
        {
            if (oglasRepository.Delete(oglas))
            {
                return new ResultWrapper
                {
                    Success = true,
                    Message = "Oglas uspešno obrisan." // Job listing successfully removed
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Greška prilikom brisanja oglasa." // Error while removing the job listing
            };
        }

        public ResultWrapper UpdateOglas(Oglas oglas)
        {
            if (oglasRepository.Update(oglas))
            {
                return new ResultWrapper
                {
                    Success = true,
                    Message = "Oglas uspešno ažuriran." // Job listing successfully updated
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Greška prilikom ažuriranja oglasa." // Error while updating the job listing
            };
        }

        public ResultWrapper GetOglasById(int id)
        {
            // Use GetAll and filter for the specific ID
            var oglas = oglasRepository.GetAll().FirstOrDefault(o => o.IdOglasa == id);

            if (oglas != null)
            {
                return new ResultWrapper
                {
                    Success = true,
                    Data = oglas, // Include the specific job listing
                    Message = "Oglas pronađen." // Job listing found
                };
            }

            return new ResultWrapper
            {
                Success = false,
                Message = "Oglas nije pronađen." // Job listing not found
            };
        }

        public List<Oglas> GetOglasByPoslodavacId(int id)
        {
            return oglasRepository.GetByPoslodavacId(id);
        }

        public List<Oglas> GetAllOglasi()
        {
            return oglasRepository.GetAll();
        }
    }
}

