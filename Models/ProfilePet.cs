﻿using SOSPets.Domain.Models.Enums;
using SOSPets.ViewModel.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Domain.Models
{
    public class ProfilePet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? UrlPhotoProfile { get; set; }
        public TypePetEnum TypePet { get; set; }
        public SizePetEnum SizePet { get; set; }
        public StageLifeEnum StageLife { get; set; }
        public DateTime DateCreatedProfile { get; set; }
        public int Fk_profile { get; set; }
        public Profile ProfileUser { get; set; }
        public IList<PhotoProfilePet>? PhotosProfilePet { get; set; }

        public ProfilePet() {}
        public ProfilePet(Profile profileUser, ProfilePetViewModelInput profileInput)
        {
            ProfileUser = profileUser;
            Name = profileInput.Name;
            Description = profileInput.Description;
            UrlPhotoProfile = profileInput.Image;
            TypePet = profileInput.TypePet;
            SizePet = profileInput.SizePet;
            StageLife = profileInput.StageLife;
            DateCreatedProfile = DateTime.Now;
        }
    }
}
