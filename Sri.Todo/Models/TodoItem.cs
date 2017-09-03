using System;
using System.Runtime.Serialization;

namespace Sri.Todo.Models
{
    [DataContract]
    public class TodoItem
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public bool IsComplete { get; set; }

        [DataMember(IsRequired =  true)]
        public int TodoListId { get; set; }

        [DataMember]
        public DateTime? CompletedAt { get; set; }

        [DataMember]
        public DateTime? CreatedAt { get; set; }
    }
}