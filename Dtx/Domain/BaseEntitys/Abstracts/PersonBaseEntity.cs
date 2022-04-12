namespace Dtx.Domain.Abstracts
{
    public class PersonBaseEntity : EntityID
    {
        public string FullName { get; set; }
        public byte Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
