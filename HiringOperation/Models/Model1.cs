using System.ComponentModel.DataAnnotations;

namespace HiringOperation.Models
{
    public class Model1
    {
        

            public int userid { get; set; }
            public string RegisterId { get; set; }
            [Required(ErrorMessage = "What's ur Name*")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
            public string FirstName { get; set; }
   
            [Required(ErrorMessage = "What's ur Name*")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "Email is required*")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]

            public string EmailID { get; set; }

            [Required(ErrorMessage = "Please enter password*")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
            [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]

            public string Password { get; set; }

            [Required(ErrorMessage = "Select Gender*")]
            public string Gender { get; set; }
            [Required(ErrorMessage = "Select DOB*")]
            public DateTime Dob { get; set; }
            [Required(ErrorMessage = "Select Role*")]

            public string Role { get; set; }
            [Required(ErrorMessage = " Status is required*")]
            public bool Status { get; set; }

            [Required(ErrorMessage = " InsertionDate is Required*")]
            public DateTime InsertionDate { get; set; }

        }
    }

