using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChkRepoDAL;
using ViewModel;

namespace ChkRepoBLL
{
    public class DataTypeMapper : Profile
    {
        public DataTypeMapper()
        {
            CreateMap<TodoItem, TodoItemVM>().ReverseMap();
        }
    }
}
