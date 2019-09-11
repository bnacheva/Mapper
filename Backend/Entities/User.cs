using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Please, enter first name. It is required."), MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please, enter last name. It is required."), MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please, enter username. It is required."), MinLength(6), MaxLength(30)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}