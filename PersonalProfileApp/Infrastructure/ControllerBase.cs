using AutoMapper;
using Dtx.Domain.Interfaces;
using PersonalProfilePersistence;
using PersonalProfilePersistence.Skills.Repositories;

namespace PersonalProfileApp.Infrastructure
{
	public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
	{
	//	protected ILogger Logger { get; }
		protected IQueryUnitOfWork QueryUnitOfWork { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected MediatR.IMediator Mediator { get; }


        protected Controller(/*ILogger logger*/MediatR.IMediator mediator, IQueryUnitOfWork queryUnitOfWork, IMapper mapper, IUnitOfWork unitOfWork)
        {
    //      Logger = logger;
            QueryUnitOfWork = queryUnitOfWork;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            Mediator = mediator;
        }
    }
}
