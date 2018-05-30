using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BansalURLShortner.Models;

namespace BansalURLShortner.Models
{
    public class URLClick
    {
        public int Id { get; set; }

        public string ShortURLNumber { get; set; }

        public int URLId { get; set; }
        public URL URL {get; set;}

        public int NumberOfClicks { get; set; }
    }
}