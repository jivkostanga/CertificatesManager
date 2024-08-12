using System.ComponentModel.DataAnnotations;

namespace CertificatesManager.Domain.Entities;

public class BaseModel
{
    [Key]
    public long Id { get; set; }
}
