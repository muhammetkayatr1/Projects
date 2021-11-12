
namespace HesProject.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;

    [Keyless]
    public  class Campus_Core_CampusCardOwnership
    {
      
        public int CardOwnershipId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public bool IsLeaver { get; set; }
        public string LeaveNote { get; set; }
        public decimal DefaultCardId { get; set; }
        public DateTime RejoinDate { get; set; }
    
    }
}
