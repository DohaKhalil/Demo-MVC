using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bl.InterFace
{
    public interface IUnitOfWork
    {
        public IDepartmentRepostiroy department { get;}
        public IEmployeeReposiroy employee { get;}

        public int Complete();

    }
}
