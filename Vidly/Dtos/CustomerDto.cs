﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToMonthlyNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Required]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}