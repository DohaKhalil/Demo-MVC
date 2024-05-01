using Demo.DaL.Model;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bl.InterFace
{
    public interface IEmployeeReposiroy : IGenaricRepositroy<Employee>
    {
        IEnumerable<Employee> GetAll(string Address);
        IEnumerable<Employee> GetAllByName(string name);
        IEnumerable<Employee> GetAllByName(Expression<Func<Employee , bool>> expression );



    }
}