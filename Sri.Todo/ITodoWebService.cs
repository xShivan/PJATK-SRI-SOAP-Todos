using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using Sri.Todo.Models;

namespace Sri.Todo
{
    [ServiceContract]
    public interface ITodoWebService
    {
        [OperationContract]
        int CreateTodoList(TodoList todoList);

        [OperationContract]
        List<TodoList> FilterTodoLists(FilterArgs filterArgs);

        [OperationContract]
        [FaultContract(typeof(AddTodoItemFaultDetails))]
        TodoItem AddTodoItem(TodoItem todoItem);
    }
}
