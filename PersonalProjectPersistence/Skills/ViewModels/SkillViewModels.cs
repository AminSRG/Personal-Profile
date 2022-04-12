using System.ComponentModel.DataAnnotations;

namespace PersonalProfilePersistence.Skills.ViewModels
{
    public class SkillViewModels
    {
        [Display(Name = "شناسه :")]
        public int ID { get; set; }
        [Display(Name = "نام :")]
        public string Title { get; set; }
        [Display(Name = "درصد :")]
        public int Percent { get; set; }
    }
}