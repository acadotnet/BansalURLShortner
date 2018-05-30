using BansalURLShortner.Data;
using BansalURLShortner.Models;
using BansalURLShortner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BansalURLShortner.Services
{
    public class EFHomeServices : IHomeServices
    {
        public readonly URLContext _context;

        public EFHomeServices(URLContext context)
        {
            _context = context;
        }

        public URLClick GetURL(string shortUrlNumber)
        {
            return _context.URLClicks.Include(u => u.URL).FirstOrDefault(u => u.ShortURLNumber == shortUrlNumber);
        }

        public void UpdateURLClicks(URLClick URLClicks)
        {
            var URLClicksToBeUpdated = _context.URLClicks.FirstOrDefault(u => u.Id == URLClicks.Id);

            URLClicksToBeUpdated.NumberOfClicks += 1;

            _context.SaveChanges();

        }

        public string CreateURL(string longUrl)
        {
            var partialUrl = longUrl.Substring(0, (longUrl.IndexOf(".com")+5));

            Guid randomId = Guid.NewGuid();
            var randomStrings = randomId.ToString().Split('-');

            partialUrl = "http://localhost:58213/home?";

            var shortUrl = String.Concat(partialUrl, randomStrings[0]);
            
            return shortUrl;
        }

        public URL LoadUrlToDatabase(URL urlToBeSaved)
        {
            _context.URLs.Add(urlToBeSaved);
            _context.SaveChanges();

            var URLClickObject = new URLClick
            {
                ShortURLNumber = urlToBeSaved.ShortURL.Split('?')[1],
                URLId = urlToBeSaved.Id,
                NumberOfClicks = 0
            };

            _context.URLClicks.Add(URLClickObject);
            _context.SaveChanges();

            return urlToBeSaved;
        }

    }
}