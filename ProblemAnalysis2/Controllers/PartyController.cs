//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemAnalysis2.Models;
using System.Linq;

namespace ProblemAnalysis2.Controllers
{
    public class PartyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var parties = _context.Parties
                .Include(p => p.Invitations) 
                .ToList();

            return View(parties);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Parties.Add(party);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(party);
        }

        public IActionResult Manage(int id)
        {
            var party = _context.Parties
                .Include(p => p.Invitations)
                .FirstOrDefault(p => p.Id == id);

            if (party == null) return NotFound();

            return View(party);
        }

        // GET: Party/Edit/{id}
        public IActionResult Edit(int id)
        {
            var party = _context.Parties.Find(id);
            if (party == null) return NotFound();
            return View(party);
        }

        // POST: Party/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Update(party);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(party);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var party = _context.Parties
                .Include(p => p.Invitations) // Ensures related invitations are included
                .FirstOrDefault(p => p.Id == id);

            if (party == null) return NotFound();

            // Delete all invitations related to this party first (to avoid foreign key issues)
            _context.Invitations.RemoveRange(party.Invitations);

            // Delete the party itself
            _context.Parties.Remove(party);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
