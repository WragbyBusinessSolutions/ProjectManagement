using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Models
{
    public class Project
    {
        [Key]
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ProjectId { get; set; }
        public decimal ProjectCost { get; set; }
        public string DocumentLink { get; set; }
        public DateTime DateUpdated { get; set; }
        public Divisions Division { get; set; }
        public Categories Category { get; set; }
        public Status Status { get; set; }
        public bool IsApproved { get; set; }
        public virtual ProjectPhase Phase { get; set; }
    }
}
