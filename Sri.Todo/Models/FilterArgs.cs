using System;

namespace Sri.Todo.Models
{
    public class FilterArgs
    {
        public string Name { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}