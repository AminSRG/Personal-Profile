using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalProfileDomain.Entitys;
using PersonalProfilePersistence.Skills.ViewModels;
using PersonalProfilePersistence.Skills.Repositories;
using PersonalProfilePersistence;
using PersonalProfileApplication.Skill.Commands;

namespace Controllers
{
    [Area("Admin")]
    public class SkillController : PersonalProfileApp.Infrastructure.Controller
    {
        public SkillController
            (MediatR.IMediator mediator,
             IMapper mapper, IQueryUnitOfWork queryUnitOfWork, IUnitOfWork unitOfWork)
                            : base(mediator: mediator, queryUnitOfWork: queryUnitOfWork, mapper: mapper, unitOfWork: unitOfWork)
        {

        }

        [HttpGet]
        [Route("/Admin/Skill/Index")]
        public IActionResult Index()
        {
            var responce = QueryUnitOfWork.Skill.GetAllAsync().Result;
            List<SkillViewModels> skillViewModels = new();
            foreach (var item in responce)
            {
                skillViewModels.Add(Mapper.Map<SkillViewModels>(item));
            }
            return View(skillViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return  View();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(SkillViewModels skillViewModels)
        {
            Skill skill = Mapper.Map<Skill>(skillViewModels);
            CreateSkillCommand request = Mapper.Map<CreateSkillCommand>(skill);
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(request);
                if (result.IsSuccess == true)
                {
                    return Redirect("/Admin/Skill/Index");
                }
                ModelState.AddModelError("Name", result.Errors.ToString());
            }
            return View(skillViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            PersonalProfileApplication.Skill.Queries.SkillQuery skillQuery = new() { ID = Id };
            var result = await Mediator.Send(skillQuery);
            if (result.IsSuccess == false)
            {
                return NotFound();
            }
            return View(result.Value);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(SkillViewModels skillViewModels)
        {
            Skill skill = Mapper.Map<Skill>(skillViewModels);
            UpdateSkillCommand request = Mapper.Map<UpdateSkillCommand>(skill);
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(request);
                if (result.IsSuccess == true)
                {
                    return Redirect("/Admin/Skill/Index");
                }
                ModelState.AddModelError("Name", result.Errors.ToString());
            }
            return View(skillViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            PersonalProfileApplication.Skill.Queries.SkillQuery skillQuery = new() { ID = Id };
            var result = await Mediator.Send(skillQuery);
            if (result.IsSuccess == false)
            {
                return NotFound();
            }
            return View(result.Value);
        }

        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(FluentResults.Result), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(SkillViewModels skillViewModels)
        {
            Skill skill = Mapper.Map<Skill>(skillViewModels);
            DeleteSkillCommand request = Mapper.Map<DeleteSkillCommand>(skill);
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(request);
                if (result.IsSuccess == true)
                {
                    return Redirect("/Admin/Skill/Index");
                }
                ModelState.AddModelError("Name", result.Errors.ToString());
            }
            return View(skillViewModels);
        }
    }
}
