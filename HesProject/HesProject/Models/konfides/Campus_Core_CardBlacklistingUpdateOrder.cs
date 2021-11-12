
namespace HesProject.Models
{
    using System;
  
    
    public  class Campus_Core_CardBlacklistingUpdateOrder
    {
       
        public int Id { get; set; }
        public int Version { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastUpdatedByUsername { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string RevisionDescription { get; set; }
        public int CardBlacklistingUpdateOrderBatchId { get; set; }
        public int ReasonId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ProccessedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime LastStateUpdateTime { get; set; }
        public string Note { get; set; }
        public int State { get; set; }
        public int BatchState { get; set; }
        public bool IsPermanent { get; set; }
        public string ErrorMessage { get; set; }
        public decimal CardId { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public byte UpdateOrderProcessState_TryCount { get; set; }
        public byte UpdateOrderProcessState_Status { get; set; }
        public DateTime UpdateOrderProcessState_StatusLastChangeTimeUtc { get; set; }
        public DateTime UpdateOrderProcessState_PostponedUntilTimeUtc { get; set; }
        public int BatchType { get; set; }
        public int ResultType { get; set; }
        public bool IsScheduled { get; set; }
    
        
    }
}
