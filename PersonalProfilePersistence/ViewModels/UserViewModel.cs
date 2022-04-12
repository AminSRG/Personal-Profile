using AutoMapper;
using Microsoft.AspNetCore.Http;
using PersonalProfileDomain.Entitys;
using System.ComponentModel.DataAnnotations;

namespace PersonalProfilePersistence.ViewModels
{
    public class UserViewModel
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string FullName { get; set; }
		[Display(Name = "شماره تلفن همراه")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string PhoneNumber { get; set; }
		[Display(Name = "سن")]
		public byte Age { get; set; }
		[Display(Name = "رمز عبور")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
        [Display(Name = "تکرار رمز عبور")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[Compare("Password")]
		[DataType(DataType.Password)]
		public string RePassword { get; set; }

		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        public string ActivateCode { get; set; }
    }


	public class UserProfile : Profile
	{
		public UserProfile() : base()
        {
			CreateMap<UserViewModel, User>();
			CreateMap<User, UserViewModel>();
        }
	}
}
