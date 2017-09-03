using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sri.Todo.Models
{
    [DataContract]
    public class TodoList : ICloneable
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember]
        public DateTime? CreatedAt { get; set; }

        [DataMember]
        public List<TodoItem> Items { get; set; }

        public object Clone()
        {
            return this;
        }
    }
}