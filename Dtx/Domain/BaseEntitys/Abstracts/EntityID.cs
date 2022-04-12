using Dtx.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtx.Domain.Abstracts
{
    public abstract class EntityID : BaseEntity, IBaseEntityID
    {
        public int ID { get; set; }
    }
}
