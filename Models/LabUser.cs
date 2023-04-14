using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LabUser
{
	public uint LabUserId { get; set; }

	[DataType(DataType.EmailAddress)]
	public string Email { get; set; } = string.Empty;

	[Display(Name = "First Name")]
	public string FirstName { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;

	[NotMapped]
	[Compare("Password", ErrorMessage = "Passwords do not match")]
	public string PasswordVerify { get; set; } = string.Empty;

}