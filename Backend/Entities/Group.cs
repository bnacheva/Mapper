using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage="Please, enter the name of the group. It is required."), MaxLength(30)]
        public string Name { get; set; }
    }
}