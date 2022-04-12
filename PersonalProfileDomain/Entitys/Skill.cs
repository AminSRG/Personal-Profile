namespace PersonalProfileDomain.Entitys
{
    public class Skill :  Dtx.Domain.Abstracts.EntityID
        {
        public string Title { get; set; }
        public byte Percent { get; set; }
        public bool IsApproved { get; set; } = false;

        public Skill(string title, byte percent)
        {
            Title = title;
            Percent = percent;
        }
        public Skill()
        {

        }
    }
}
