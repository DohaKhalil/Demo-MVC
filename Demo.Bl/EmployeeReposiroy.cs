using Demo.Bl.InterFace;
using Demo.DaL.DataContext;
using Demo.DaL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo.Bl
{
    public class EmployeeReposiroy : GenaricRepositroy<Employee>, IEmployeeReposiroy
    {
      public EmployeeReposiroy(CompanyDataContext companyDataContext) : base(companyDataContext)
      {

      }
        
        public IEnumerable<Employee> GetAll(string Address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllByName(string name)
        {
          return _companyDataContext.Employee.Where(e=>e.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public IEnumerable<Employee> GetAllByName(Expression<Func<Employee, bool>> expression)
        {
            return _companyDataContext.Employee.Include(e=>e.Deparntment).Where(expression).ToList();

        }
    }
}
