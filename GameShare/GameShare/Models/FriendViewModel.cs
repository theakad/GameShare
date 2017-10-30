using GameShare.Entity.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GameShare.Models
{
    public class FriendViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        public virtual IEnumerable<Game> Games { get; set; }

        public static implicit operator FriendViewModel(Friend friend)
        {
            return new FriendViewModel
            {
                Id = friend.Id,
                Name = friend.Name,
                Email = friend.Email,
                Games = friend.Games
            };
        }

        public static implicit operator Friend(FriendViewModel friendViewModel)
        {
            return new Friend
            {
                Id = friendViewModel.Id,
                Name = friendViewModel.Name,
                Email = friendViewModel.Email,
                Games = friendViewModel.Games.ToList()
            };
        }
    }
}