namespace Resume_Builder_MAUI.Model;

public class UserModel
{
    // Basic Info
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string JobField { get; set; } = string.Empty;
    public string PortfolioUrl { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;

    // Education, Work Experience, Certificates (multiple entries)
    public List<EducationEntry> Education { get; set; } = [];
    public List<WorkEntry> WorkExperience { get; set; } = [];
    public List<CertificateEntry> Certificates { get; set; } = [];
}

public class EducationEntry
{
    public string InstitutionName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}

public class WorkEntry
{
    public string CompanyName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}

public class CertificateEntry
{
    public string CertificateName { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}