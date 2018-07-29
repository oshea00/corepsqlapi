using System;
using System.Collections.Generic;

namespace webapi.api.Models
{
    public partial class Todos
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Iscomplete { get; set; }
    }
}
