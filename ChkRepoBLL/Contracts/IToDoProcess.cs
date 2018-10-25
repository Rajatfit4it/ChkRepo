using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ChkRepoBLL.Contracts
{
    public interface IToDoProcess
    {
        List<TodoItemVM> GetAll();
        TodoItemVM GetById(long id);
        TodoItemVM Add(TodoItemVM item);
        bool Update(long id, TodoItemVM item);
        bool Delete(long id);
    }
}
