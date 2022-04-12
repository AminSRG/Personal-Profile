namespace PersonalProfileDomain.Entitys
{
    public class Exprience : Dtx.Domain.Abstracts.EntityID
    {
        public string? Title { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public bool? IsApproved { get; set; } = false;

    }
}
