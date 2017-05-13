using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Sri.Todo.Models;

namespace Sri.Todo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TodoWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TodoWebService.svc or TodoWebService.svc.cs at the Solution Explorer and start debugging.
    public class TodoWebService : ITodoWebService
    {
        private readonly Services.TodoService todoService = new Services.TodoService();

        public int CreateTodoList(TodoList todoList)
        {
            int todoListId = this.todoService.Add(todoList);
            return todoListId;
        }

        public List<TodoList> FilterTodoLists(FilterArgs filterArgs)
        {
            IList<TodoList> todoLists = this.todoService.GetAll();

            if (!String.IsNullOrWhiteSpace(filterArgs.Name))
                todoLists = todoLists.Where(tdl => tdl.Name.Contains(filterArgs.Name)).ToList();

            if (filterArgs.DateFrom.HasValue)
                todoLists = todoLists.Where(tdl => tdl.CreatedAt >= filterArgs.DateFrom.Value).ToList();

            if (filterArgs.DateTo.HasValue)
                todoLists = todoLists.Where(tdl => tdl.CreatedAt <= filterArgs.DateTo.Value).ToList();

            return todoLists.ToList();
        }
        
        public TodoItem AddTodoItem(TodoItem todoItem)
        {
            TodoItem createdTodoItem = this.todoService.AddItem(todoItem);
            if (createdTodoItem == null)
                throw new FaultException<AddTodoItemFaultDetails>(new AddTodoItemFaultDetails("Todo list with such ID does not exist."), "Business logic violation");

            return createdTodoItem;
        }
    }
}
