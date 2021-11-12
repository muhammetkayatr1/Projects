namespace HesProject.Models
{
    using System;
    public  class SharedKernel_PersonalityBase
    {
           
        public int Id { get; set; }
        public int Version { get; set; }
        public int IndividualId { get; set; }
        public bool IsOverallPrimaryPersonality { get; set; }
        public bool IsTypePrimaryPersonality { get; set; }
        public bool IsActive { get; set; }
        public int TierOneId { get; set; }
        public int TierTwoId { get; set; }
        public int TierThreeId { get; set; }
        public int TierFourId { get; set; }
        public int PersonalityTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PersonalityIdInfo { get; set; }
        public string InfoLine1 { get; set; }
        public string InfoLine2 { get; set; }
        public string InfoLine3 { get; set; }
        public string InfoLine4 { get; set; }
        public int PositionId { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public int EndingReasonId { get; set; }
        public bool IsEnded { get; set; }
        public string EndedBy { get; set; }
        public string EndingNote { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastUpdatedByUsername { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string RevisionDescription { get; set; }
       }
}
