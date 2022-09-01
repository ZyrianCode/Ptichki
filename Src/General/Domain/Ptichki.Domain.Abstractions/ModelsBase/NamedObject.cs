using System.ComponentModel.DataAnnotations;

namespace Ptichki.Domain.Abstractions.ModelsBase
{
    public abstract class NamedObject : DomainObject
    {
        [Required] public string Name { get; set; }
    }
}