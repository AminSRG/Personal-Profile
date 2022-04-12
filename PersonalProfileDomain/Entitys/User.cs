namespace PersonalProfileDomain.Entitys
{
    public class User : Dtx.Domain.Abstracts.PersonBaseEntity
    {
        public string? ActivateCode { get; set; }
        public bool IsActivate { get; set; } = false;
        public string? ProfilePhoto { get; set; }
        public string? PassWord { get; set; }
    }
}
