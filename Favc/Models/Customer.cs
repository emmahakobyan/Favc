﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Favc.Models
{
    public class Customer
    {
        public int Id { get; set; }

       /* [Required(ErrorMessage = "Please enter Customer's Name")]*/
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [Min18yearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public bool IsSubcribeToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}