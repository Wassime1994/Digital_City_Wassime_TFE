namespace Digital_City_Wassime_TFE.Models
{
    public class Patient
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string problem { get; set; }
        public int level { get; set; }
        public DateTime date_entry { get; set; }
        public string statut { get; set; }
    }

    public class PatientForm
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string problem { get; set; }
        public int level { get; set; }
        public DateTime date_entry { get; set; }
        public string statut { get; set; }
    }

}
