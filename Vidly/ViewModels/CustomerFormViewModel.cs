﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public string Title { get; set; }

        public List<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}