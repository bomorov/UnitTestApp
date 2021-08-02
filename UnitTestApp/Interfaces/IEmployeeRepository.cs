using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UnitTestApp.Data;
using UnitTestApp.Models;

namespace UnitTestApp.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<string> GetById(int EmpId);

        Task<Employee> GetEmployeeDetails(int EmpID);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetById(int EmpId)
        {
            return await _context.Employees.Where(x => x.Id == EmpId).Select(x => x.Name).FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeDetails(int EmpID)
        {
            return await _context.Employees.FirstOrDefaultAsync(c => c.Id == EmpID);
        }
    }
}