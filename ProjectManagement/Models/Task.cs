using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class Task
    {
        [Key]
        public string Id { get; set; }
        public string Category { get; set; }
        public virtual Project Project { get; set; }
        public string AssignedTo { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
    }
}
