using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfileApplication.Skill.CommandHandlers
{
    public class UpdateSkillCommandHandler : object,
		Dtx.Mediator.IRequestHandler
					   <Commands.UpdateSkillCommand>
	{
		public UpdateSkillCommandHandler
			(Dtx.Logging.ILogger<UpdateSkillCommandHandler> logger,
			AutoMapper.IMapper mapper,
			PersonalProfilePersistence.IUnitOfWork unitOfWork) : base()
		{
			Logger = logger;
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected PersonalProfilePersistence.IUnitOfWork UnitOfWork { get; }

		protected Dtx.Logging.ILogger<UpdateSkillCommandHandler> Logger { get; }

		public
			async
			System.Threading.Tasks.Task
			<FluentResults.Result>
			Handle(Commands.UpdateSkillCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result();

			try
			{
				// **************************************************
				var skill = Mapper.Map<PersonalProfileDomain.Entitys.Skill>(source: request);
				// **************************************************

				// **************************************************
				await UnitOfWork.Skill.UpdateAsync(entity: skill);

				await UnitOfWork.SaveAsync();
				// **************************************************

				// **************************************************
				string successInsert =
					string.Format(PersonalProfileResources.Messages.SuccessInsert, nameof(PersonalProfileDomain.Entitys.Skill));

				result.WithSuccess
					(successMessage: successInsert);
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
