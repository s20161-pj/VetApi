﻿namespace VetApp.DataAccess.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string SpeciesOfThePet { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string NameOfThePetOwner { get; set; }
        public string SurnameOfThePetOwner { get; set; }
        public string PetAddress { get; set; }
        public Client Client {get; set;}

    }
}
