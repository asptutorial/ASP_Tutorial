using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootstrapSiteLCD.Models;

namespace BootstrapSiteLCD.ViewModels
{
    public class StudentViewModel
    {
        public Student students { get; set; }

        public Address addresses { get; set; }
    }
}