using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.PagedRequestModels
{
    public class PagedRequest
    {
        public PagedRequest()
        {
            RequestFilters = new RequestFilters();
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ColumnNameForSorting { get; set; } = String.Empty;

        public string SortDirection { get; set; } = String.Empty;

        public RequestFilters RequestFilters { get; set; }
    }
}
