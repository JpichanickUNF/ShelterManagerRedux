using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ShelterManagerRedux.Models
{
    public class ClientView
    {
        [Key]
        public int Shelter_Location_ID { get; set; }

        public string Shelter_Location_Description { get; set; }


        public int AvailableSpace { get; set; }

        public int TotalSpace { get; set; }


    }
}
