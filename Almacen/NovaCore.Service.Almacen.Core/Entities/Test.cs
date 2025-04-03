using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaCore.Common.Core.Base;

namespace NovaCore.Service.Almacen.Core.Entities
{
    public class Test : EntityBase
    {
        public Test()
        {
        }
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


}