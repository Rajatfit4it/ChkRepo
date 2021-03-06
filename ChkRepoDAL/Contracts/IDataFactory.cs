﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChkRepoDAL.Contracts
{
    public interface IDataFactory
    {
        T GetData<T>() where T : IData;
    }
}
