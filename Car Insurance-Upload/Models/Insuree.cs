// Models/Insuree.cs
// Author: Liudmila Poliakova
// Academy of Learning College
// This model represents an insurance applicant and their car details

using System;
using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Models
{
    public class Insuree
    {
        // Primary key - unique identifier for each insuree
        public int Id { get; set; }

        // First name of the insuree
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Last name of the insuree
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Email address of the insuree
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        // Date of birth - used to calculate age for the quote
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // The year the car was manufactured
        [Required]
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        // The make (brand) of the car e.g. Toyota, Porsche
        [Required]
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }

        // The model of the car e.g. Camry, 911 Carrera
        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        // Whether the insuree has ever had a DUI
        [Required]
        [Display(Name = "DUI")]
        public bool DUI { get; set; }

        // Number of speeding tickets the insuree has
        [Required]
        [Display(Name = "Speeding Tickets")]
        public int SpeedingTickets { get; set; }

        // Coverage type - true = Full Coverage, false = Liability
        [Required]
        [Display(Name = "Full Coverage")]
        public bool CoverageType { get; set; }

        // The calculated monthly insurance quote (not entered by the user)
        [Display(Name = "Quote")]
        [DataType(DataType.Currency)]
        public decimal Quote { get; set; }
    }
}
