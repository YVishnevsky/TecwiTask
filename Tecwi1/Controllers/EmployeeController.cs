using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tecwi1.Models;
using Tecwi1.Repositories;
using Tecwi1.Requests;

namespace Tecwi1.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) => 
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            return View(Mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, EmployeeDto employeeDto)
        {
            try
            {
                await _employeeRepository.UpdateAsync(Mapper.Map<Employee>(employeeDto));
            }
            catch 
            {
                return View(employeeDto);
            }

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> New(EmployeeDto employeeDto)
        {
            try
            {
                await _employeeRepository.AddNewAsync(Mapper.Map<Employee>(employeeDto));
            }
            catch
            {
                return View(employeeDto);
            }

            return RedirectToAction("Index");
        }
    }
}