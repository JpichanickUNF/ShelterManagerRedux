using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterManagerRedux.Models

{
    public class Manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagerID { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string AssignedShelter { get; set; }

        /*[Key]
         public int ManagerID { get; set; }

         [Required(ErrorMessage = "First Name is required.")]
         public string? Firstname { get; set; }

         [Required(ErrorMessage = "Last Name is required.")]
         public string Lastname { get; set; }

         [Required(ErrorMessage = "Username is required.")]
         public string Username { get; set; }

         [Required(ErrorMessage = "Email is required.")]
         [EmailAddress(ErrorMessage = "Invalid email format.")]
         public string Email { get; set; }

         [Required(ErrorMessage = "Password is required.")]
         [DataType(DataType.Password)]
         public string Password { get; set; }

         [Required(ErrorMessage = "Phone Number is required.")]
         [Phone(ErrorMessage = "Invalid phone number format.")]
         public int Phone_Number { get; set; }

         [Required(ErrorMessage = "Assigned Shelter is required.")]
         public string Assigned_Shelter { get; set; }
        */
    }
}
