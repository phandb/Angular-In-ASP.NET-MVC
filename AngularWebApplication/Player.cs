//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularWebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Player
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
        public System.DateTime JoinedClubOn { get; set; }
    }
}
