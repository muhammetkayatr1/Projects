
namespace HesProject.Models
{
    using System;
   
    public  class Bo_Card
    {
       
        public decimal Id { get; set; }
        public int Version { get; set; }
        public int TerminalEodGroupId { get; set; }
        public int BalanceTransfer_OrderId { get; set; }
        public decimal LastKnownBalance { get; set; }
        public DateTime LastKnownBalanceReportTime { get; set; }
        public string SerialNumberHexString { get; set; }
        public bool SerialNumberHexStringIsBigEndian { get; set; }
        public long SerialNumber56Bit { get; set; }
        public int SerialNumber24Bit { get; set; }
        public int ChipType { get; set; }
        public int OwnershipId { get; set; }
        public int LastCardLimitLoadingNumber { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastUpdatedByUsername { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string RevisionDescription { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public DateTime FirstParameterUpdateTime { get; set; }
        public DateTime FirstOnlineLoadingTime { get; set; }
        public DateTime FirstOfflineLoadingTime { get; set; }
        public DateTime FirstDebitTime { get; set; }
        public DateTime FirstCreditTime { get; set; }
        public DateTime FirstUsageTime { get; set; }
        public DateTime LastParameterUpdateTime { get; set; }
        public DateTime LastOnlineLoadingTime { get; set; }
        public DateTime LastOfflineLoadingTime { get; set; }
        public DateTime LastDebitTime { get; set; }
        public DateTime LastCreditTime { get; set; }
        public DateTime LastUsageTime { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public string SerialNumberHexStringInBigEndian { get; set; }
        public string SerialNumberHexStringInLittleEndian { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsBlacklisted { get; set; }
        public int OwnerId { get; set; }
        public int LastBlacklistingOrderId { get; set; }
        public bool IsVisitorCard { get; set; }
        public bool IsActivated { get; set; }
        public bool IsActivatedWhileActivationWasNotMandatory { get; set; }
        public DateTime ActivationTime { get; set; }
        public decimal ActivatedOnTerminalId { get; set; }
        public int ActivationRequestId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsPermanentlyBlacklistedFeedbackReceived { get; set; }
        public bool IsPermanentlyBlacklisted { get; set; }
        public bool CashierParameters_IsCashierCard { get; set; }
        public string CashierParameters_Pin { get; set; }
        public decimal CashierParameters_RemainingLimitAmount { get; set; }
        public decimal CashierParameters_CollectedAmountAcked { get; set; }
        public decimal CashierParameters_CollectedAmountAwaitingAck { get; set; }
        public DateTime CashierParameters_LastCashierCardUsageTime { get; set; }
        public bool CashierParameters_IsLocked { get; set; }
        public int CashierParameters_WrongPinEntryCount { get; set; }
        public DateTime CashierParameters_LastLockTime { get; set; }
        public bool CashierParameters_IsActive { get; set; }
        public int PersonalityId { get; set; }
        public bool IsTemporaryCard { get; set; }
        public bool IsAttached { get; set; }
        public DateTime MealRightParameters_MealRightBeginDate { get; set; }
        public DateTime MealRightParameters_MealRightEndDate { get; set; }
        public DateTime MealRightParameters_LastMealRightUpdateTime { get; set; }
        public byte NedapSiteCode { get; set; }
        public int NedapTagNumber { get; set; }
        public string NedapFullNumberString { get; set; }    
      
    }
}
