using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yanzhilongapi.Models;

namespace yanzhilong.Controllers
{
    public class BrowsingController : ApiController
    {
        Browsing[] browsings = new Browsing[]
        {
            new Browsing { Id = Guid.NewGuid().ToString(), Url = "https://www.baidu.com/", CreateDate = DateTime.Now, UserId = Guid.NewGuid().ToString() },
            new Browsing { Id = Guid.NewGuid().ToString(), Url = "https://www.baidu.com/", CreateDate = DateTime.Now, UserId = Guid.NewGuid().ToString() },
            new Browsing { Id = Guid.NewGuid().ToString(), Url = "https://www.baidu.com/", CreateDate = DateTime.Now, UserId = Guid.NewGuid().ToString() }
        };

        public IEnumerable<Browsing> GetAllBrowsings()
        {
            return browsings;
        }

        public IHttpActionResult GetBrowsing(string Id)
        {
            var browsing = browsings.FirstOrDefault((p) => p.Id == Id);
            if (browsing == null)
            {
                return NotFound();
            }
            return Ok(browsing);
        }
    }
}
