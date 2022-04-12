namespace PersonalProfileDomain.Entitys
{
    public class Personal : Dtx.Domain.Abstracts.PersonBaseEntity
    {
        public string? Language { get; set; }
        public string? Address { get; set; }
        public string? About { get; set; }
        public string? ImageName { get; set; }
        public string? ProfilePhotoName { get; set; }
    }
}