using Demo.Bl.InterFace;
using Demo.DaL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bl
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly Lazy <IDepartmentRepostiroy> _department;
        private readonly Lazy <IEmployeeReposiroy> _employee;
        private readonly CompanyDataContext _companyDataContext;

        public UnitOfWork(CompanyDataContext companyDataContext)
        {
            _department = new Lazy<IDepartmentRepostiroy> (new DepartmentRepostiroy(companyDataContext));
            _employee = new Lazy<IEmployeeReposiroy>(new EmployeeReposiroy(companyDataContext));
            _companyDataContext = companyDataContext;
        }


        public IDepartmentRepostiroy department => _department.Value;

        public IEmployeeReposiroy employee => _employee.Value;

        public int Complete() => _companyDataContext.SaveChanges();

        public void Dispose()
        {
            _companyDataContext.Dispose(); 
        }
    }
}