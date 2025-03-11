//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemAnalysis2.Models;

namespace ProblemAnalysis2.Controllers
{
    public class RSVPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSVPController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /RSVP/{id}
        [HttpGet("/rsvp/{id}")]
        public IActionResult Index(int id)
        {
            var invitation = _context.Invitations.Find(id);
            if (invitation == null) return NotFound();

            return View(invitation);
        }

        // POST: /RSVP/Submit
        [HttpPost]
        public IActionResult Submit(int invitationId, string response)
        {
            var invitation = _context.Invitations.Find(invitationId);
            if (invitation == null) return NotFound();

            // Update the status based on the response
            if (response == "yes")
            {
                invitation.Status = InvitationStatus.RespondedYes;
            }
            else if (response == "no")
            {
                invitation.Status = InvitationStatus.RespondedNo;
            }

            _context.SaveChanges();

            // Redirect to Thank You Page
            return RedirectToAction("ThankYou");
        }

        // GET: /RSVP/ThankYou
        [HttpGet("/rsvp/thankyou")]
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
