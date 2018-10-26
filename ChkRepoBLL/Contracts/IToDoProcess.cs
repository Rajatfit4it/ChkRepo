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

        Task<List<TodoItemVM>> GetAllAsync();
        Task<TodoItemVM> GetByIdAsync(long id);
        Task<TodoItemVM> AddAsync(TodoItemVM item);
        Task<bool> UpdateAsync(long id, TodoItemVM item);
        Task<bool> DeleteAsync(long id);
    }
}
