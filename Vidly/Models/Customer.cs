using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Is subscribed to monthly News Letter?")]
        public bool IsSubscribedToMonthlyNewsLetter { get; set; }

        [Display(Name = "Memebership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? BirthDate { get; set; }
    }
}