using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfileApplication.Skill.QueryHandlers
{
    public class SkillQueryHandler : object,
		Dtx.Mediator.IRequestHandler
		<Queries.SkillQuery, PersonalProfilePersistence.Skills.ViewModels.SkillViewModels>
	{
		public SkillQueryHandler
			(Dtx.Logging.ILogger<SkillQueryHandler> logger,
			AutoMapper.IMapper mapper,
			PersonalProfilePersistence.IUnitOfWork unitOfWork) : base()
		{
			Logger = logger;
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected PersonalProfilePersistence.IUnitOfWork UnitOfWork { get; }

		protected Dtx.Logging.ILogger<SkillQueryHandler> Logger { get; }

		public
			async
			System.Threading.Tasks.Task
			<FluentResults.Result
				<PersonalProfilePersistence.Skills.ViewModels.SkillViewModels>>
			Handle(Queries.SkillQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result
				<PersonalProfilePersistence.Skills.ViewModels.SkillViewModels>();

			try
			{
				// **************************************************
				var skill =
					await
					UnitOfWork.Skill
					.GetByIdAsync(id: request.ID)
					;
				// **************************************************
				PersonalProfilePersistence.Skills.ViewModels.SkillViewModels skillViewModels =
					Mapper.Map<PersonalProfilePersistence.Skills.ViewModels.SkillViewModels>(skill);
				// **************************************************
				result.WithValue(value: skillViewModels);
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(exception: ex, message: ex.Message);

				result.WithError
					(errorMessage: ex.Message);
			}

			return result;
		}
	}
}
