using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShelterManagerRedux.Models

{
    public class ShelterProfile
    {
        [Key]
        [Required(ErrorMessage = "Shelter Name  is required")]
        public string ShelterName { get; set; }
        [Required(ErrorMessage = "Manager Name  is required")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Phone Number  is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Operating Hours are required")]
        public string Hours { get; set; }

    }
}
