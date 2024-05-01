using Demo.Bl.InterFace;
using Demo.DaL.DataContext;
using Demo.DaL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bl
{
    public class DepartmentRepostiroy : GenaricRepositroy<Deparntment> ,IDepartmentRepostiroy
    {
        public DepartmentRepostiroy(CompanyDataContext companyDataContext):base(companyDataContext)
        {

        }
    }
}
