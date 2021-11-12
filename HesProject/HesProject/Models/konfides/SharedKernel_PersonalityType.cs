namespace HesProject.Models
{

    
    public  class SharedKernel_PersonalityType
    {
       
    
        public int Id { get; set; }
        public int Version { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonalityIdInfoUniquelessLevel { get; set; }
        public string PersonalityTypeSpecificNameOfTier1 { get; set; }
        public string PersonalityTypeSpecificNameOfTier2 { get; set; }
        public string PersonalityTypeSpecificNameOfTier3 { get; set; }
        public string PersonalityTypeSpecificNameOfTier4 { get; set; }
        public string PersonalityTypeSpecificNameOfPosition { get; set; }
        public string PersonalityTypeSpecificNameOfInfoLine1 { get; set; }
        public string PersonalityTypeSpecificNameOfInfoLine2 { get; set; }
        public string PersonalityTypeSpecificNameOfInfoLine3 { get; set; }
        public string PersonalityTypeSpecificNameOfInfoLine4 { get; set; }
        public string PersonalityTypeSpecificNameOfPersonalityIdInfo { get; set; }
        public int DefaultTier1Id { get; set; }
        public int DefaultTier2Id { get; set; }
        public int DefaultTier3Id { get; set; }
        public int DefaultTier4Id { get; set; }
        public int DefaultTier1ForAutomaticCreationId { get; set; }
        public int DefaultTier2ForAutomaticCreationId { get; set; }
        public int DefaultTier3ForAutomaticCreationId { get; set; }
        public int DefaultTier4ForAutomaticCreationId { get; set; }
        public int DefaultPositionId { get; set; }
        public int DefaultPositionForAutomaticCreationId { get; set; }
        public bool IsPositionMandatory { get; set; }
        public bool IsPersonalityIdInfoMandatory { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public int Foid { get; set; }
    
         }
}
