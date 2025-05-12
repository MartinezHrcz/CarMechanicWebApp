using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Mechanic.Shared.Modells;

public class Work
{
    
    [JsonIgnore]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [JsonIgnore]
    [ForeignKey(nameof(clientFK))] public Client? Client { get; set; }
    
    [Required]
    public int clientFK { get; set; }

    [Required]
    [RegularExpression("^[A-Z]{3}-\\d{3}$$")]
    private string licensePlate;
    public string LicensePlate { get => licensePlate; set => licensePlate = value; }
    
    [Required]
    [Range(1900, 2025)]
    private int productionDate;
    public int ProductionDate { get => productionDate; set => productionDate = value; }
    
    [Required]
    private WorkCategories workCategory;
    public WorkCategories WorkCategory { get => workCategory; set => workCategory = value; }
    
    [Required]
    [MaxLength(2000)]
    private string shortDescription;
    public string ShortDescription { get => shortDescription; set => shortDescription = value; }
    
    [Required]
    private int severity;
    public int Severity { get => severity; set => severity = value; }
    
    
} 