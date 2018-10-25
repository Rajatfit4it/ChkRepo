using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChkRepoDAL.Contracts
{
    public interface IToDoData
    {
        List<TodoItem> GetAll();
        TodoItem GetById(long id);
        TodoItem Add(TodoItem item);
        bool Update(long id, TodoItem item);
        bool Delete(long id);
    }
}
