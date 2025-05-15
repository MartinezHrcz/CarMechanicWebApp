using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Mechanic.Shared.Modells;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    [MaxLength(50)]
    private string name;
    public string Name { get => name; set => name = value; }
    
    [Required]
    [EmailAddress]
    private string email;
    public string Email { get => email; set => email = value; }
    
    [Required]
    private string address;
    public string Address { get => address; set => address = value; }
    
    
}