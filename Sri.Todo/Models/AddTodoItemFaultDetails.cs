using System;
using System.Web.Services.Protocols;

namespace Sri.Todo.Models
{
    public class AddTodoItemFaultDetails
    {
        public string FaultMessage;

        public AddTodoItemFaultDetails()
        {
            
        }

        public AddTodoItemFaultDetails(string faultMessage)
        {
            this.FaultMessage = faultMessage;
        }
    }
}