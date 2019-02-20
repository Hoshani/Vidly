using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Is subscribed to monthly News Letter?")]
        public bool IsSubscribedToMonthlyNewsLetter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Required]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}