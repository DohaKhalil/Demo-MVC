using Demo.Bl.InterFace;
using Demo.DaL.DataContext;
using Demo.DaL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bl
{
    public class GenaricRepositroy<T> : IGenaricRepositroy<T> where T : class
    {
        protected readonly CompanyDataContext _companyDataContext;
        public GenaricRepositroy(CompanyDataContext companyDataContext)
        {
            _companyDataContext = companyDataContext;
        }
        public void Add(T entity)
        {
            _companyDataContext.Set<T>().Add(entity);
            
        }
        public void Delete(T entity)
        {
            _companyDataContext.Set<T>().Remove(entity);
        }
        public T Get(int id) => _companyDataContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
        {
            if(typeof(T)== typeof(Employee))
            {
                return (IEnumerable<T>) _companyDataContext.Employee.Include(D =>D.Deparntment).ToList();    
            }
           return _companyDataContext.Set<T>().ToList();
        }
    
        public void Update(T entity)
        {
            _companyDataContext.Set<T>().Update(entity);

        }
    }
}
