using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using yanzhilong.Domain;
using yanzhilong.Service;
using yanzhilongapi.Models;

namespace yanzhilong.Controllers
{
    public class BrowsingController : ApiController
    {
        private readonly BrowsingService _BrowsingService;

        public BrowsingController(BrowsingService BrowsingService)
        {
            _BrowsingService = BrowsingService;
        }

        [ResponseType(typeof(IEnumerable<Browsing>))]
        public IHttpActionResult GetAllBrowsings()
        {
            List<Browsing> Browsings = _BrowsingService.GetEntrys(new Browsing()).ToList();
            return Ok(Browsings);
        }

        [ResponseType(typeof(Browsing))]
        public IHttpActionResult GetBrowsing(string Id)
        {
            Guid guid = Guid.Empty;
            if (!Guid.TryParse(Id,out guid)){
                return NotFound();
            }
            var browsing = _BrowsingService.GetEntry(new Browsing { Id = Id });
            if (browsing == null)
            {
                return NotFound();
            }
            return Ok(browsing);
        }

        public void Post(BrowsingModel browsing) {
            browsing.Id = Guid.NewGuid().ToString();
            Browsing b = new Browsing
            {
                Id = browsing.Id,
                Url = browsing.Url,
                Browser = browsing.Browser,
                CreateDate = DateTime.Now,
                Tag = browsing.Tag,
                UserId = browsing.UserId
            };
            _BrowsingService.AddEntry(b);
        }

        public void Put(string Id, BrowsingModel browsing) {
            Browsing b = new Browsing
            {
                Id = Id,
                Url = browsing.Url,
                Browser = browsing.Browser,
                CreateDate = browsing.CreateDate,
                Tag = browsing.Tag,
                UserId = browsing.UserId
            };
            _BrowsingService.UpdateEntry(b);
        }

    }
}
