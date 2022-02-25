﻿using System.Collections.Generic;

namespace MAV.Common.Models
{
    public class InternRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<LoanRequest> Loans { get; set; }

    }
}
