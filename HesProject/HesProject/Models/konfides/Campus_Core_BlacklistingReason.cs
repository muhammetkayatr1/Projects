namespace HesProject.Models
{
    using System;

    public  class Campus_Core_BlacklistingReason
    {
       
        public int Id { get; set; }
        public int Version { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastUpdatedByUsername { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string RevisionDescription { get; set; }
        public bool IsPermanent { get; set; }
        public string PosTextFormat { get; set; }
        public int Status { get; set; }
        public bool IsAvailableForWebUI { get; set; }
        public bool IsAvailableForWebService { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletionTime { get; set; }
        public string DeletedBy { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public string ShinkaTextFormatLine1 { get; set; }
        public string ShinkaTextFormatLine2 { get; set; }
        public string ShinkaTextFormatLine3 { get; set; }
        public int Foid { get; set; }
    
       
    }
}
