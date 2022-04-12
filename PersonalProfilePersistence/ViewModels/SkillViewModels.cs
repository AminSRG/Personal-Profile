using AutoMapper;
using PersonalProfileDomain.Entitys;
using System.ComponentModel.DataAnnotations;

namespace PersonalProfilePersistence.ViewModels
{
    public class SkillViewModels
    {
		[Display(Name = "شناسه :")]
		public int ID { get; set; }

        [Display(Name = "نام :")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Title { get; set; }

		[Display(Name = "درصد :")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[Range(0, 100, ErrorMessage = "مقدار وارد شده بین 0 و 100 باشد")]
		public byte Percent { get; set; }
	}

	public class SkillProfile : Profile
	{
        public SkillProfile() : base()
        {
			CreateMap<Skill, SkillViewModels>();
			CreateMap<SkillViewModels, Skill>();
		}
	}
}
