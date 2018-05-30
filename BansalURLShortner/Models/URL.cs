using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BansalURLShortner.Models
{
    public class URL
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Original URL")]
        public string OriginalURL { get; set; }

        [Display(Name = "Your Shortened URL is: ")]
        public string ShortURL { get; set; }

    }
}