using Dtx.Domain.Interfaces;
using System;

namespace Dtx.Domain.Abstracts
{
    public abstract class BaseEntity : IBaseEntitys
    {
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    }
}
