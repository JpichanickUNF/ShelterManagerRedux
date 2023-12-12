using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShelterManagerRedux.Models

{
    public class ShelterProfile
    {
        [Key]
        [Required(ErrorMessage = "Shelter ID  is required")]
        public int ShelterID { get; set; }
        [Required(ErrorMessage = "Shelter Name  is required")]
        public string Shelter_name { get; set; }

        public string Contact_name { get; set; }

        [Required(ErrorMessage = "Phone Number  is required")]
        public int Phone_number { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Operating Hours are required")]
        public int Operation_hours { get; set; }
    }
}
