//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemAnalysis2.Models
{
    public enum InvitationStatus
    {
        InviteNotSent = 0,
        InviteSent,
        RespondedYes,
        RespondedNo
    }

    public class Invitation
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        public string GuestName { get; set; }

        [Required, EmailAddress]
        public string GuestEmail { get; set; }

        [Required]
        public InvitationStatus Status { get; set; } = InvitationStatus.InviteNotSent;

        // Foreign Key
        public int PartyId { get; set; }

        // Navigation Property
        public Party Party { get; set; }

        public void Respond(InvitationStatus status)
        {
            Status = status;
        }

    }


}
