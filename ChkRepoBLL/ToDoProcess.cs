using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChkRepoBLL.Contracts;
using ChkRepoDAL;
using ViewModel;
using AutoMapper;
using ChkRepoDAL.Contracts;

namespace ChkRepoBLL
{
    public class ToDoProcess : IToDoProcess
    {
        private readonly IToDoData _toDoData;
        private readonly IMapper _mapper;
        public ToDoProcess(IToDoData toDoData, IMapper mapper)
        {
            _toDoData = toDoData;
            _mapper = mapper;
        }
        public List<TodoItemVM> GetAll()
        {
            return _mapper.Map<List<TodoItemVM>>(_toDoData.GetAll());
        }

        public TodoItemVM GetById(long id)
        {
            return _mapper.Map<TodoItemVM>(_toDoData.GetById(id));
        }

        public TodoItemVM Add(TodoItemVM item)
        {
            TodoItem itemDal = _mapper.Map<TodoItem>(item);
            var response = _toDoData.Add(itemDal);
            return _mapper.Map<TodoItemVM>(response);

        }

        public bool Update(long id, TodoItemVM item)
        {
            TodoItem itemDal = _mapper.Map<TodoItem>(item);
            return _toDoData.Update(id, itemDal);
        }

        public bool Delete(long id)
        {
            return _toDoData.Delete(id);
        }
    }
}
