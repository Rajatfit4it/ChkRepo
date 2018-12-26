using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChkRepoBLL.Contracts
{
    public interface IProcessFactory
    {
        T GetProcess<T>() where T : IProcess;
    }
}
