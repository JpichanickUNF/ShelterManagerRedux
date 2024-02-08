using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterManagerRedux.Models

{
    namespace ShelterManagerRedux
    {
        public class LoginViewModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }

}
