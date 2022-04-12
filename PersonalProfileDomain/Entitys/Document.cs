namespace PersonalProfileDomain.Entitys
{
    public class Document : Dtx.Domain.Abstracts.EntityID
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public bool IsApproved { get; set; } = false;
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Date { get; set; }
    }
}
