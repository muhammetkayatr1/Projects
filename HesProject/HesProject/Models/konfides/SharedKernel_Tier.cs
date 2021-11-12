namespace HesProject.Models
{
    using System;
    
    public partial class SharedKernel_Tier
    {
        
        public int Id { get; set; }
        public int Version { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TierLevel { get; set; }
        public int BoundUpperTierSelectionType { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastUpdatedByUsername { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string RevisionDescription { get; set; }
        public int BoundPersonalitySelectionType { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public int Foid { get; set; }
    
           }
}
