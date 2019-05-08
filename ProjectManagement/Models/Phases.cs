using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class Phases
    {
        [Key]
        public string Id { get; set; }
        public virtual Methodologies Methoology { get; set; }
        public string PhaseName { get; set; }
    }
}
