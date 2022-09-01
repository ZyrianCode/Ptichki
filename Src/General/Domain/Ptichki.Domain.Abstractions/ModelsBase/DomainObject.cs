namespace Ptichki.Domain.Abstractions.ModelsBase
{
    public abstract class DomainObject : IEntity
    {
        public int Id { get; set; }
    }
}
