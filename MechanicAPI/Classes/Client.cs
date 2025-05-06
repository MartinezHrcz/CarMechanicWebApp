using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicAPI.Classes;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private string id;
    public string Id { get => id; set => id = value; }
    
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