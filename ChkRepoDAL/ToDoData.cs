using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChkRepoDAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChkRepoDAL
{
    public class ToDoData : IToDoData
    {
        private readonly TodoContext _context;

        public ToDoData(TodoContext context)
        {
            _context = context;

            if (!_context.TodoItems.Any())
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem {Name = "Item1"});
                _context.TodoItems.Add(new TodoItem {Name = "Item2"});
                _context.TodoItems.Add(new TodoItem {Name = "Item3"});
                _context.SaveChanges();
            }
        }

        public List<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public TodoItem GetById(long id)
        {
            return _context.TodoItems.Find(id);
        }

        public async Task<TodoItem> GetByIdAsync(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public TodoItem Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<TodoItem> AddAsync(TodoItem item)
        {
            await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public bool Update(long id, TodoItem item)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return false;
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return true;
        }

        public async  Task<bool> UpdateAsync(long id, TodoItem item)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return false;
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return false;
            }
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

