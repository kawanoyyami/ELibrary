using Common.Models.PagedRequestModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.PagedRequestModels
{
    public class RequestFilters
    {
        public IList<Filter> Filters { get; set; }
        public FilterLogicalOperators LogicalOperators { get; set; }
        public RequestFilters()
        {
            Filters = new List<Filter>();
        }
    }
}
