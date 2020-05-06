using System;
using System.Collections.Generic;

namespace StudentRegistrationAPI.Models
{
    public partial class TableStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public int? Grade { get; set; }
        public string City { get; set; }
    }
}
