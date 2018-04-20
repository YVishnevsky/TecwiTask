using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Tecwi1.Models;

namespace Tecwi1.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly TecwiDbContext _dbContext;

        public EmployeeRepository(TecwiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> GetCountAsync(string searchText = null)
        {
            var query = GetFilteredQueriable(_dbContext.Employees, searchText);

            return await query.CountAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Employee>> GetListAsync(int from, int count, string searchText, IEnumerable<(string fieldName, string direction)> sortFields)
        {
            var query = GetFilteredQueriable(_dbContext.Employees.AsNoTracking(), searchText);

            return await query.Order(sortFields).Skip(from).Take(count).ToListAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = new Employee { Id = id };
            _dbContext.Employees.Attach(employee);
            _dbContext.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private IQueryable<Employee> GetFilteredQueriable(IQueryable<Employee> query, string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(em => em.Age.ToString().Contains(searchText)
                    || em.Name.Contains(searchText)
                    || em.Position.Contains(searchText)
                    || em.StartDate.ToString().Contains(searchText));
            }

            return query;
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id).ConfigureAwait(false);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employeeToUpdate = await GetAsync(employee.Id);
            _dbContext.Entry(employeeToUpdate).CurrentValues.SetValues(employee);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}