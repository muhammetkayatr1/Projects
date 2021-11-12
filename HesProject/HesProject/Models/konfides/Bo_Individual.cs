
namespace HesProject.Models
{
    using System;

    
    public class Bo_Individual
    {
       
        public int Id { get; set; }
        public int Version { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int OccupationId { get; set; }
        public string LandlinePhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public int PhotoId { get; set; }
        public string EmailAddress { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public decimal Ssn { get; set; }
        public int TitleId { get; set; }
        public byte Gender { get; set; }
        public int MaritalStatus { get; set; }
        public string HomePhoneNumber { get; set; }
        public string ContactPerson { get; set; }
        public bool IsContact { get; set; }
        public string WUIUserName { get; set; }
        public string WUIUserPassword { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public int CardOwnershipId { get; set; }
        public int OverallPrimaryPersonalityId { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastUpdatedByUsername { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string RevisionDescription { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InheritRegularMailAddress { get; set; }
        public bool UseRMAAsCardDeliveryAddress { get; set; }
        public string MiddleName { get; set; }
        public int CardDeliveryDestinationPointId { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string MaidenName { get; set; }
        public string MothersMaidenName { get; set; }
        public int BloodType { get; set; }
        public string NufusaKayitliOlduguIl { get; set; }
        public string NufusaKayitliOlduguIlce { get; set; }
        public string NufusaKayitliOlduguMahalleKoy { get; set; }
        public int NufusKayitCiltNo { get; set; }
        public int NufusKayitSayfaNo { get; set; }
        public int NufusKayitKutukNo { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }
        public bool IsVisitor { get; set; }
        public string DirectMessage { get; set; }
        public int LastEnteredLocationId { get; set; }
    
         }
}
