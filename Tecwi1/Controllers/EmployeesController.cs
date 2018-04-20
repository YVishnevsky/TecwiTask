using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tecwi1.Models;
using Tecwi1.Repositories;
using Tecwi1.Requests;
using Tecwi1.Responses;

namespace Tecwi1.Controllers
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository) => 
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

        [Route("")]
        public async Task<IHttpActionResult> Get([FromUri]DataTableRequest request)
        {
            var sortCollumns = request.Order.Select(o => (fieldName: request.Columns[o.Column].Name, order: o.Dir));

            var emloyees = await _employeeRepository.GetListAsync(request.Start, request.Length, request.Search.Value, sortCollumns);

            return Ok(new EmployeesResponse
            {
                Draw = request.Draw,
                RecordsTotal = await _employeeRepository.GetCountAsync(),
                RecordsFiltered = await _employeeRepository.GetCountAsync(request.Search.Value),
                Data = Mapper.Map<IEnumerable<EmployeeDto>>(emloyees)
            });
        }

        [Route("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
