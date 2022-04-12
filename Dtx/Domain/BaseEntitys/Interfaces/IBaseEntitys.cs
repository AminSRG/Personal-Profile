using System;

namespace Dtx.Domain.Interfaces
{
    public interface IBaseEntitys
    {
        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
