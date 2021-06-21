using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Feature.Home.Models
{
    public class Admission
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateofBirth { get; set; }

        public string Course { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId{ get; set; }
        public string Address { get; set; }
    }
}