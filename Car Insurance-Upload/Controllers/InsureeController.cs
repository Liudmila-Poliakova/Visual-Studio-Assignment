// Controllers/InsureeController.cs
// Author: Liudmila Poliakova
// Academy of Learning College
// This controller handles all CRUD operations for Insurees and calculates insurance quotes

using System;
using System.Linq;
using System.Threading.Tasks;
using CarInsurance.Data;
using CarInsurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        // Database context - used to interact with the database
        private readonly ApplicationDbContext _context;

        // Constructor - injects the database context
        public InsureeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ── INDEX ──────────────────────────────────────────────
        // GET: Insuree
        // Displays a list of all insurees in the database
        public async Task<IActionResult> Index()
        {
            // Retrieve all insurees from the database and pass to the view
            return View(await _context.Insurees.ToListAsync());
        }

        // ── DETAILS ────────────────────────────────────────────
        // GET: Insuree/Details/5
        // Displays the details of a single insuree
        public async Task<IActionResult> Details(int? id)
        {
            // Return error if no id was provided
            if (id == null)
                return NotFound();

            // Find the insuree with the matching id
            var insuree = await _context.Insurees.FirstOrDefaultAsync(m => m.Id == id);

            // Return error if no insuree was found
            if (insuree == null)
                return NotFound();

            return View(insuree);
        }

        // ── CREATE (GET) ────────────────────────────────────────
        // GET: Insuree/Create
        // Displays the form to create a new insuree
        public IActionResult Create()
        {
            return View();
        }

        // ── CREATE (POST) ───────────────────────────────────────
        // POST: Insuree/Create
        // Receives the form data, calculates the quote, and saves to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Requirement 1: Calculate the quote before saving
                insuree.Quote = CalculateQuote(insuree);

                // Add the new insuree to the database
                _context.Add(insuree);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Redirect to the index page after saving
                return RedirectToAction(nameof(Index));
            }

            return View(insuree);
        }

        // ── EDIT (GET) ──────────────────────────────────────────
        // GET: Insuree/Edit/5
        // Displays the form to edit an existing insuree
        public async Task<IActionResult> Edit(int? id)
        {
            // Return error if no id was provided
            if (id == null)
                return NotFound();

            // Find the insuree with the matching id
            var insuree = await _context.Insurees.FindAsync(id);

            // Return error if insuree was not found
            if (insuree == null)
                return NotFound();

            return View(insuree);
        }

        // ── EDIT (POST) ─────────────────────────────────────────
        // POST: Insuree/Edit/5
        // Saves the updated insuree data and recalculates the quote
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            // Return error if the id does not match
            if (id != insuree.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Recalculate the quote with updated information
                    insuree.Quote = CalculateQuote(insuree);

                    // Update the insuree in the database
                    _context.Update(insuree);

                    // Save changes to the database
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // If the insuree no longer exists, return error
                    if (!_context.Insurees.Any(e => e.Id == insuree.Id))
                        return NotFound();
                    else
                        throw;
                }

                // Redirect to the index page after saving
                return RedirectToAction(nameof(Index));
            }

            return View(insuree);
        }

        // ── DELETE (GET) ────────────────────────────────────────
        // GET: Insuree/Delete/5
        // Displays the delete confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            // Return error if no id was provided
            if (id == null)
                return NotFound();

            // Find the insuree with the matching id
            var insuree = await _context.Insurees.FirstOrDefaultAsync(m => m.Id == id);

            // Return error if insuree was not found
            if (insuree == null)
                return NotFound();

            return View(insuree);
        }

        // ── DELETE (POST) ────────────────────────────────────────
        // POST: Insuree/Delete/5
        // Permanently deletes the insuree from the database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the insuree to delete
            var insuree = await _context.Insurees.FindAsync(id);

            // Remove the insuree from the database
            _context.Insurees.Remove(insuree);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the index page after deleting
            return RedirectToAction(nameof(Index));
        }

        // ── ADMIN VIEW ───────────────────────────────────────────
        // Requirement 3: Admin view showing all quotes with name and email
        // GET: Insuree/Admin
        public async Task<IActionResult> Admin()
        {
            // Retrieve all insurees from the database for the admin view
            return View(await _context.Insurees.ToListAsync());
        }

        // ── CALCULATE QUOTE ──────────────────────────────────────
        // Private method that calculates the monthly insurance quote
        // based on the insuree's information - Requirement 1
        private decimal CalculateQuote(Insuree insuree)
        {
            // Start with a base monthly rate of $50
            decimal quote = 50m;

            // Calculate the insuree's age from their date of birth
            int age = DateTime.Today.Year - insuree.DateOfBirth.Year;

            // Adjust age if birthday hasn't occurred yet this year
            if (insuree.DateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;

            // Requirement 1b: Add $100 if the user is 18 or under
            if (age <= 18)
                quote += 100m;

            // Requirement 1c: Add $50 if the user is between 19 and 25
            else if (age >= 19 && age <= 25)
                quote += 50m;

            // Requirement 1d: Add $25 if the user is 26 or older
            else if (age >= 26)
                quote += 25m;

            // Requirement 1e: Add $25 if the car was made before 2000
            if (insuree.CarYear < 2000)
                quote += 25m;

            // Requirement 1f: Add $25 if the car was made after 2015
            if (insuree.CarYear > 2015)
                quote += 25m;

            // Requirement 1g: Add $25 if the car make is Porsche
            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25m;

                // Requirement 1h: Add an additional $25 if the model is a 911 Carrera
                // (total of $50 added for this specific car)
                if (insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25m;
            }

            // Requirement 1i: Add $10 for every speeding ticket the user has
            quote += insuree.SpeedingTickets * 10m;

            // Requirement 1j: Add 25% to the total if the user has had a DUI
            if (insuree.DUI)
                quote *= 1.25m;

            // Requirement 1k: Add 50% to the total if it is full coverage
            if (insuree.CoverageType)
                quote *= 1.50m;

            // Round the quote to 2 decimal places and return it
            return Math.Round(quote, 2);
        }
    }
}
