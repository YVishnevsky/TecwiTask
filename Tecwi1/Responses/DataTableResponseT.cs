using System.Collections.Generic;
using Tecwi1.Requests;

namespace Tecwi1.Responses
{
    public abstract class DataTableResponse<T> where T : EmployeeDto
    {
        public int Draw { get; set; }

        public int RecordsTotal { get; set; }

        public int RecordsFiltered { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}