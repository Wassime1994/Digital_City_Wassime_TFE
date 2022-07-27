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
    public class PatientAllService
    {
        public PatientAllService(PatientAllRepository repo)
        {
            this.repo = repo;
        }

        public PatientAllRepository repo { get; set; }

        public IEnumerable<PatientAllDTO> GetAll()
        {
            return repo.GetAll().Select(r => r.ToDTO());
        }

        public bool Remove(int idPatient)
        {
            return repo.Remove(idPatient);
        }

        public PatientAllDTO Add(PatientAllDTO dto)
        {
            int idPatient = repo.Add(dto.ToEntity());
            dto.id = idPatient;
            return dto;

        }



        public bool Update(int id, PatientAllDTO dto)
        {
            return repo.Update(id, dto.ToEntity());
        }
    }
}
