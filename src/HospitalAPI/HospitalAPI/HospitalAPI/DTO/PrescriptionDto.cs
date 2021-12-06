namespace HospitalAPI.DTO
{
    public class PrescriptionDto
    {
        public string PharmacyUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PatientName { get; set; }

        public PrescriptionDto()
        { }

        public PrescriptionDto(string url, string name, string description, string patienName)
        {
            PharmacyUrl = url;
            Name = name;
            Description = description;
            PatientName = patienName;
        }


    }
}