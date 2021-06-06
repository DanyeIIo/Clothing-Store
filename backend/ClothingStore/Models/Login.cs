using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Infrastructure.Persistence.Models;

namespace ClothingStore.Models
{
    // public class Login
    // {
    //     [Required]
    //     [NotNull]
    //     public string Name { get; set; }
    //     
    //     [Required]
    //     [NotNull]
    //     public string Surname { get; set; }
    //             
    //     [Required]
    //     public string Patronymic { get; set; }
    //             
    //     [Required]
    //     [NotNull]
    //     public DateTime BirthDate { get; set; }
    //             
    //     [Required]
    //     [EmailAddress]
    //     public string Email { get; set; }
    //             
    //     [Required]
    //     public string Nickname { get; set; }
    //     
    //     [Phone]
    //     [Required]
    //     [NotNull]
    //     public string PhoneNumber { get; set; }
    //     
    //     [Required]
    //     public string Avatar { get; set; }
    //     
    //     //public int RoleId { get; set; }
    //     public string Password { get; set; }
    //
    //     [Required]
    //     [NotNull]
    //     public Role Role { get; set; }
    // }
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}