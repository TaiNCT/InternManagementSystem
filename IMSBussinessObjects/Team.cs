﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Team Name is required")]
        public string TeamName { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Supervisor> Supervisors { get; set; }
        public ICollection<Intern> Interns { get; set; }
        public ICollection<Interview> Interviews { get; set; }

    }
}