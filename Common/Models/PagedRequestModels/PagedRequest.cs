using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.PagedRequestModels
{
    public class PagedRequest
    {
        public RequestFilters RequestFilters { get; set; }
        public PagedRequest()
        {
            RequestFilters = new RequestFilters();
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ColumnNameForSorting { get; set; }

        public string SortDirection { get; set; }
    }
}
