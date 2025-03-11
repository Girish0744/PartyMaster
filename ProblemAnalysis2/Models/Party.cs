//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProblemAnalysis2.Models
{
    public class Party
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string Location { get; set; }

        // Navigation Property (One Party -> Many Invitations)
        public List<Invitation> Invitations { get; set; } = new List<Invitation>();
    }
}
