using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Model.Pet
{
    public class GetPetDto
    {
        public int Id { get; set; }
        public string SpeciesOfThePet { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string NameOfThePetOwner { get; set; }
        public string SurnameOfThePetOwner { get; set; }
        public string PetAddress { get; set; }
    }
}
