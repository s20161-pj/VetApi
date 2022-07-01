namespace VetApp.Model.Pet
{
    public class AddPetDto
    {
        public string SpeciesOfThePet { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string NameOfThePetOwner { get; set; }
        public string SurnameOfThePetOwner { get; set; }
        public string PetAddress { get; set; }
        public int ClientId { get; set; }
    }
}
