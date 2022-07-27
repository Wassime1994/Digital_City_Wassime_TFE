namespace Digital_City_Wassime_TFE.Models
{
    public class PatientOut
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string problem { get; set; }
        public int level { get; set; }
        public DateTime date_entry { get; set; }
        public string statut { get; set; }


    }

    public static class TestAjout
    {

    
        public static  PatientOut ToPatientOut(this Patient element)
        {
            // Do dome stuff, subscribe to an event of T

            return new PatientOut()
            {
                id = element.id,
                firstName = element.firstName,
                lastName = element.lastName,
                level = element.level,
                statut = element.statut,
                date_entry = element.date_entry,
                problem = element.problem
            };
            
            }
        }

    }


