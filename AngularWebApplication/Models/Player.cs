using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularWebApplication.Models
{
    public class Player
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Player name is required", AllowEmptyStrings = false)]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Club name is required", AllowEmptyStrings = false)]
        public string Club { get; set; }

        [Required(ErrorMessage = "Player position required", AllowEmptyStrings = false)]
        public string Position { get; set; }

        [Required(ErrorMessage = "Player joined date is required", AllowEmptyStrings = false)]
        public DateTime JoinedClubOn { get; set; }


    }
}