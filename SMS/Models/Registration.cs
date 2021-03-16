using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseId { get; set; }
        public string BatchId { get; set; }
        public int[] PhoneNo { get; set; }
        public string Email { get; set; }
    }
}