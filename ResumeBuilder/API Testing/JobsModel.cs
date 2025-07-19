using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing
{
    public class JobsModel
    {
        public string? jobPublisher { get; set; }
        public string? jobId { get; set; }
        public string? jobTitle { get; set; }
        public string? companyName { get; set; }
        public string? companyLogo { get; set; }
        public string? companyWebsite { get; set; }
        public string? jobEmploymentType { get; set; }
        public string? jobApplyLink { get; set; }
        public string? jobDescription { get; set; }
        public string? jobLocation { get; set; }
        public string? jobCategory { get; set; }
        public string? jobSalary { get; set; }
        public string? jobStatus { get; set; } = string.Empty;
        public string? jobPostedAt { get; set; }
    }
}
