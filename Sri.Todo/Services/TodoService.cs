using System;
using System.Collections.Generic;
using System.Linq;
using Sri.Todo.Extensions;
using Sri.Todo.Models;

namespace Sri.Todo.Services
{
    public class TodoService
    {
        private static readonly List<TodoList> listCache = new List<TodoList>();

        public int Add(TodoList todoList)
        {
            int newId = listCache.Any() ? listCache.Select(tdl => Convert.ToInt32(tdl.Id)).Max() + 1 : 1;
            todoList.Id = newId;
            todoList.CreatedAt = DateTime.UtcNow;
            todoList.Items = new List<TodoItem>();
            listCache.Add(todoList);
            return newId;
        }

        public IList<TodoList> GetAll()
        {
            return listCache.Clone();
        }

        public TodoItem AddItem(TodoItem todoItem)
        {
            TodoList todoList = listCache.SingleOrDefault(tdl => tdl.Id == todoItem.TodoListId);
            if (todoList == null)
                return null;

            int newId = todoList.Items.Any() ? todoList.Items.Select(tdi => Convert.ToInt32(tdi.Id)).Max() + 1 : 1;
            TodoItem newTodoItem = new TodoItem()
            {
                Id = newId,
                CreatedAt = DateTime.UtcNow,
                Name = todoItem.Name,
                TodoListId = todoList.Id.Value,
                IsComplete = todoItem.IsComplete,
                CompletedAt = todoItem.CompletedAt
            };

            todoList.Items.Add(newTodoItem);

            return newTodoItem;

        }
    }
}