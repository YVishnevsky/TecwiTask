using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecwi1.Controllers;
using Tecwi1.Repositories;
using Xunit;

namespace Tecwi1.Tests
{
    public class EmployeesControllerTests
    {
        [Fact]
        public async Task Delete_Employee()
        {
            var mockRepository = new Mock<IEmployeeRepository>();
            var controller = new EmployeesController(mockRepository.Object);
            int id = 99;
            await controller.Delete(id);
            mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }
    }
}
