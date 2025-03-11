//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemAnalysis2.Models;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ProblemAnalysis2.Controllers
{
    public class InvitationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvitationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ADD NEW INVITATION
        [HttpPost]
        public IActionResult AddInvitation(int partyId, string guestName, string guestEmail)
        {
            var invitation = new Invitation
            {
                GuestName = guestName,
                GuestEmail = guestEmail,
                PartyId = partyId,
                Status = InvitationStatus.InviteNotSent
            };

            _context.Invitations.Add(invitation);
            _context.SaveChanges();

            return RedirectToAction("Manage", "Party", new { id = partyId });
        }

        // SEND INVITATIONS
        [HttpPost]
        public IActionResult SendInvitationsByPartyId(int id)
        {
            var party = _context.Parties.Include(p => p.Invitations)
                          .FirstOrDefault(p => p.Id == id);

            if (party == null) return NotFound();

            foreach (var invitation in party.Invitations.Where(i => i.Status == InvitationStatus.InviteNotSent))
            {
                string subject = $"You're Invited: {party.Description}";
                string body = $"Hello {invitation.GuestName},<br><br>You are invited to {party.Description} on {party.EventDate.ToShortDateString()}.";

                SendEmail(invitation.GuestEmail, subject, body, invitation.Id);

                invitation.Status = InvitationStatus.InviteSent;
            }

            _context.SaveChanges();
            return RedirectToAction("Manage", "Party", new { id });
        }



        // EMAIL SENDING FUNCTION
        private void SendEmail(string to, string subject, string body, int invitationId)
        {
            try
            {
                var fromAddress = new MailAddress("girishbhuteja07@gmail.com", "Girish Bhuteja");
                var toAddress = new MailAddress(to);
                const string fromPassword = "ajleddniswpplito"; // Use your correct App Password

                var smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                // ✅ Correctly format RSVP Link
                string rsvpLink = $"https://localhost:7061/rsvp/{invitationId}";
                if (Request != null)
                {
                    var request = Request.HttpContext.Request;
                    rsvpLink = $"{request.Scheme}://{request.Host}/rsvp/{invitationId}";
                }

                string fullBody = $@"
            <p>Hello,</p>
            <p>You are invited to an event!</p>
            <p>{body}</p>
            <p><b>Click below to RSVP:</b></p>
            <p><a href='{rsvpLink}' 
                  style='display:inline-block; padding:10px 20px; font-size:16px; color:white; background-color:#007bff; text-decoration:none; border-radius:5px;'>
                  Respond Here
                </a></p>
            <p>Thank you!</p>";

                using var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = fullBody,
                    IsBodyHtml = true
                };

                smtp.Send(message);
                Console.WriteLine($"Email sent successfully to {to}");
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Error: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error sending email: {ex.Message}");
            }
        }


    }
}
