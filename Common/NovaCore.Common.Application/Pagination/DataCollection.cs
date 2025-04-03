using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaCore.Common.Application.Pagination
{
    public class DataCollection<T>
    {
        public bool HasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }

        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}