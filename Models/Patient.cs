namespace PatientViewerAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
        public string Diagnosis { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime AdmissionDate { get; set; } = DateTime.UtcNow;
        public DateTime? DischargeDate { get; set; }
    }
}
