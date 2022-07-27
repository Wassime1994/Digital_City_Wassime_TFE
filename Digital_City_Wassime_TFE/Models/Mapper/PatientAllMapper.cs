using BLL.DTO;

namespace Digital_City_Wassime_TFE.Models.Mapper
{
    public static class PatientAllMapper
    {

            public static PatientAll ToModelAll(this PatientAllDTO dto)
            {
                return new PatientAll()
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

        public static PatientAllDTO ToDTO(this PatientAll dto)
        {
            return new PatientAllDTO()
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
    }
    }

