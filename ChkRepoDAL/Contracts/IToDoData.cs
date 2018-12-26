using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChkRepoDAL.Contracts
{
    public interface IToDoData : IData
    {
        List<TodoItem> GetAll();
        TodoItem GetById(long id);
        TodoItem Add(TodoItem item);
        bool Update(long id, TodoItem item);
        bool Delete(long id);

        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(long id);
        Task<TodoItem> AddAsync(TodoItem item);
        Task<bool> UpdateAsync(long id, TodoItem item);
        Task<bool> DeleteAsync(long id);
    }
}
