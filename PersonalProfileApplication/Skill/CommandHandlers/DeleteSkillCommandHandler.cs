using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfileApplication.Skill.CommandHandlers
{
    public class DeleteSkillCommandHandler : object,
		Dtx.Mediator.IRequestHandler
					   <Commands.DeleteSkillCommand>
	{
		public DeleteSkillCommandHandler
			(Dtx.Logging.ILogger<DeleteSkillCommandHandler> logger,
			AutoMapper.IMapper mapper,
			PersonalProfilePersistence.IUnitOfWork unitOfWork) : base()
		{
			Logger = logger;
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected PersonalProfilePersistence.IUnitOfWork UnitOfWork { get; }

		protected Dtx.Logging.ILogger<DeleteSkillCommandHandler> Logger { get; }

		public
			async
			System.Threading.Tasks.Task
			<FluentResults.Result>
			Handle(Commands.DeleteSkillCommand request,
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
				await UnitOfWork.Skill.DeleteAsync(entity: skill);

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
