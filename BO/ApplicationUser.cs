using System;
using System.Collections.Generic;

namespace BO
{
    public class ApplicationUser : Personne
    {
        public string _RoleAdministrateur;
        public string _RoleSuperAdministrateur;
        public string _RoleUser;

        public DateTime BirthDate { get; set; }
        public ICollection<DisplayConfiguration> DisplayConfigurations { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public ApplicationUser()
        {
        }

        public ApplicationUser(string roleAdministrateur, string roleSuperAdministrateur, string roleUser, DateTime birthDate, ICollection<DisplayConfiguration> displayConfigurations, string firstName, string lastName, string phone)
        {
            _RoleAdministrateur = roleAdministrateur;
            _RoleSuperAdministrateur = roleSuperAdministrateur;
            _RoleUser = roleUser;
            BirthDate = birthDate;
            DisplayConfigurations = displayConfigurations;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}