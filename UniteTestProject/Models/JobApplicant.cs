namespace UniteTestProject.Models
{
    public class JobApplicant
    {
        public Applicant Applicant { get; set; } = null!;
        public int YearsOfExperience { get; set; }
        public List<string> TechStackList { get; set; } = null!;
    }
}
