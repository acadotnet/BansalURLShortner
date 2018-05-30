using BansalURLShortner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BansalURLShortner.Services.Interfaces
{
    public interface IHomeServices
    {
        URLClick GetURL(string shortUrlNumber);

        string CreateURL(string longUrl);

        URL LoadUrlToDatabase(URL urlToBeSaved);

        void UpdateURLClicks(URLClick URLClicks);
    }
}