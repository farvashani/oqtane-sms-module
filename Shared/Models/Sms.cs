using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Tres.Smss.Models
{
    [Table("TresSms")]
    public class Sms : IAuditable
    {
        public int SmsId { get; set; }
        public int ModuleId { get; set; }
        public string PhoneNbr { get; set; }
        public string Message { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}