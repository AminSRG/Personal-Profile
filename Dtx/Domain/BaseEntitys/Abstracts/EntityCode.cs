using Dtx.Domain.Interfaces;

namespace Dtx.Domain.Abstracts
{
    public abstract class EntityCode : BaseEntity, IBaseEntityCode
    {   
        public byte Code { get; set; }
    }
}