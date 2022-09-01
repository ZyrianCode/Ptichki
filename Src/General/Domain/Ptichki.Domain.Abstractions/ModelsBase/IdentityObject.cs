namespace Ptichki.Domain.Abstractions.ModelsBase
{
    public abstract class IdentityObject : NamedObject
    {
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}