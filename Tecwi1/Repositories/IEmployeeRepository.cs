using System.Collections.Generic;
using System.Threading.Tasks;
using Tecwi1.Models;

namespace Tecwi1.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetListAsync(int from, int count, string searchText, IEnumerable<(string fieldName, string direction)> sortFields);
        Task<int> GetCountAsync(string searchText = null);
        Task<Employee> GetAsync(int id);

        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}