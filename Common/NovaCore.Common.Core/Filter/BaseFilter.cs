using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaCore.Common.Core.Filter
{
    public class BaseFilter
    {
        
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Search { get; set; }
    }
}