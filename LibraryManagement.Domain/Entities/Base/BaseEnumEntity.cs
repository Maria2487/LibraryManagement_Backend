namespace LibraryManagement.Domain.Entities.Base
{
    public record BaseEnumEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
