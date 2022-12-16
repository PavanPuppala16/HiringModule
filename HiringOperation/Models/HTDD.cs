using System.ComponentModel.DataAnnotations;

namespace HiringOperation.Models
{
    public class HTDD
    {
      

            public int HTDID { get; set; }
            public int Sno { get; set; }


            public string HallTicket { get; set; }
            [Required(ErrorMessage = "What's ur Name*")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Email is required*")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
            public string EmailID { get; set; }
            [Required(ErrorMessage = "select Dob*")]
            public DateTime Dob { get; set; }
            [Required(ErrorMessage = " Gender is requried*")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Mobile is required*")]
            [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
            public string StudentPHno { get; set; }
            [Required(ErrorMessage = "Mobile is required*")]
            [RegularExpression(@"\d{12}", ErrorMessage = "Please enter 12 digit Aadhar  No.")]
            public string StudentAadhar { get; set; }

            public string SchoolName { get; set; }
            public DateTime SscPassYear { get; set; }
            public float SscAggregate { get; set; }

            public string CollegeName { get; set; }
            public DateTime IntermediatePassYear { get; set; }
            public float IntermediateAggregate { get; set; }

            public string EngineeringCollegeName { get; set; }
            public string Branch { get; set; }
            public DateTime EngineeringPassout { get; set; }

            public int Backlog { get; set; }
            public float GraduationAggregate { get; set; }

            public string FathersName { get; set; }
            public string PermanentAddress { get; set; }
            public string FathersMobileNo { get; set; }
            public string MothersName { get; set; }
            public string MothersOccupation { get; set; }


        
    }
}
