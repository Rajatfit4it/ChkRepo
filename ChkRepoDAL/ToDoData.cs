using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChkRepoDAL.Contracts;

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

        public TodoItem GetById(long id)
        {
            return _context.TodoItems.Find(id);
        }

        public TodoItem Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
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
    }

}

