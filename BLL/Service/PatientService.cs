using BLL.DTO;
using BLL.Mapper;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PatientService
    {
        public PatientService(PatientRepository repo)
        {
            this.repo = repo;
        }

        public PatientRepository repo { get; set; }

        public IEnumerable<PatientDTO> GetAll()
        {
            return repo.GetAll().Select(r => r.ToDTO());
        }

        public bool Remove(int idPatient)
        {
            return repo.Remove(idPatient);
        }

        public PatientDTO Add(PatientDTO dto)
        {
            int idPatient = repo.Add(dto.ToEntity());
            dto.id = idPatient;
            return dto;

        }



        public bool Update(int id , PatientDTO dto)
        {
            return repo.Update(id, dto.ToEntity()); 
        }
    }
}
