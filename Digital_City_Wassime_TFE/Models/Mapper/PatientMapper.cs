using BLL.DTO;

namespace Digital_City_Wassime_TFE.Models.Mapper
{
    public static  class PatientMapper
    {
        public static Patient ToModel(this PatientDTO dto )
        {
            return new Patient()
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
