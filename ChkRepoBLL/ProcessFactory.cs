using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChkRepoBLL.Contracts;

namespace ChkRepoBLL
{
    public class ProcessFactory : IProcessFactory
    {
        IServiceProvider serviceProvider;
        public ProcessFactory(IServiceProvider sProvider)
        {
            serviceProvider = sProvider;
        }

        public T GetProcess<T>() where T : IProcess
        {
            var instanceVal = serviceProvider.GetService(typeof(T));
            return (T)instanceVal;
        }
    }
}
