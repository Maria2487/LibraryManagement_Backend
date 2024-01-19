namespace LibraryManagement.Domain.Entities.Base
{
    [Serializable]
    public record BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
