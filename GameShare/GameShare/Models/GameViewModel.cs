using GameShare.Entity.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GameShare.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [MaxLength(30)]
        [Display(Name = "Tipo")]
        public string Style { get; set; }

        [MaxLength(500)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Está Emprestado?")]
        public bool IsAvailable { get; set; }

        public int? FriendId { get; set; }

        public virtual Friend Friend { get; set; }

        public static implicit operator GameViewModel(Game game)
        {
            return new GameViewModel
            {
                Id = game.Id,
                Description = game.Description,
                Friend = game.Friend,
                FriendId = game.FriendId,
                Image = game.Image,
                IsAvailable = game.IsAvailable,
                Style = game.Style,
                Title = game.Title
            };
        }

        public static implicit operator Game(GameViewModel gameViewModel)
        {
            return new Game
            {
                Id = gameViewModel.Id,
                Description = gameViewModel.Description,
                Friend = gameViewModel.Friend,
                FriendId = gameViewModel.FriendId,
                Image = gameViewModel.Image,
                IsAvailable = gameViewModel.IsAvailable,
                Style = gameViewModel.Style,
                Title = gameViewModel.Title
            };
        }
    }
}