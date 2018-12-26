using System;
using ChkRepoDAL.Contracts;

namespace ChkRepoDAL
{
    public class DataFactory : IDataFactory
    {
        IServiceProvider serviceProvider;
        public DataFactory(IServiceProvider sProvider)
        {
            serviceProvider = sProvider;
        }

        public T GetData<T>() where T : IData
        {
            var instanceVal = serviceProvider.GetService(typeof(T));
            return (T)instanceVal;
        }
    }
}
