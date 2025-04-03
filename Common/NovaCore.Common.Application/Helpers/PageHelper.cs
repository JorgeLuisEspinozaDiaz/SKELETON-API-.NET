using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaCore.Common.Application.Helpers
{
    public class PageHelper
    {
        public int calcularPages(int take, int total)
        {
            if (take <= 0 || take >= total) return 1;

            return (int)Math.Ceiling((double)total / take);
        }
    }
}