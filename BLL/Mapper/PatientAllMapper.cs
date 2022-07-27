using BLL.DTO;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public static class PatientAllMapper
    {
        public static PatientAllEntity ToEntity(this PatientAllDTO dto)
        {
            return new PatientAllEntity()
            {


                id = dto.id,
                lastName = dto.lastName,
                firstName = dto.firstName,
                problem = dto.problem,
                level = dto.level,
                statut = dto.statut,
                date_entry = dto.date_entry

            };
        }
        public static PatientAllDTO ToDTO(this PatientAllEntity entity)
        {
            return new PatientAllDTO()
            {
                id = entity.id,
                lastName = entity.lastName,
                firstName = entity.firstName,
                problem = entity.problem,
                level = entity.level,
                statut = entity.statut,
                date_entry = entity.date_entry

            };
        }
    }
}
