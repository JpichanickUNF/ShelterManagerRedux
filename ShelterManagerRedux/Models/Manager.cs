using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Manager
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ManagerID { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    public string Firstname { get; set; }

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
}
