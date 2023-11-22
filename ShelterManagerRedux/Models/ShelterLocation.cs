using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShelterManagerRedux.Models

{
    public class ShelterLocation
    {
        [Key]
        public int Shelter_Location_ID { get; set; }
        public string Shelter_Location_Description { get; set; }
    }
}
