using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.PagedRequestModels.Enums
{
    public enum FilterOperators
    {
        Contains = 0,
        Equals = 1,
        EqualsNumber = 2,
        NotEqualsNumber = 3,
        Custom = 4,
    }
}
