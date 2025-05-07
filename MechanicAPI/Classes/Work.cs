using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;


namespace MechanicAPI.Classes;

public class Work
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private string id;
    public string Id
    {
        get => id;
        set => id = value;
    }
    [JsonIgnore]
    [ForeignKey(nameof(clientFK))] public Client? Client { get; set; }

    public string clientFK { get; set; }

    [Required]
    private string licensePlate;
    public string LicensePlate { get => licensePlate; set => licensePlate = value; }
    
    private DateOnly productionDate;
    public DateOnly ProductionDate { get => productionDate; set => productionDate = value; }
    
    private WorkCategories workCategory;
    public WorkCategories WorkCategory { get => workCategory; set => workCategory = value; }

    private string shortDescription;
    public string ShortDescription { get => shortDescription; set => shortDescription = value; }
    
    private int severity;
    public int Severity { get => severity; set => severity = value; }
    
    
} 