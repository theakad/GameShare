using GameShare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameShare.Models
{
    public class HomeViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public static implicit operator HomeViewModel(User user)
        {
            return new HomeViewModel
            {
                Username = user.Username,
                Password = user.Password
            };
        }

        public static implicit operator User(HomeViewModel homeViewModel)
        {
            return new User
            {
                Username = homeViewModel.Username,
                Password = homeViewModel.Password
            };
        }
    }
}