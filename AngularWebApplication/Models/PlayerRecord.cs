using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularWebApplication.Models
{
    public class PlayerRecord
    {
        [Key]
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public string Club { get; set; }

        public string Position { get; set; }

        public DateTime JoinedClubOn { get; set; }
    }
}