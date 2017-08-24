using Microsoft.Web.Http;
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
    /// <summary>
    /// 浏览记录接口
    /// </summary>
    [ApiVersion("1.0")]   
    public class BrowsingController : ApiController
    {
        private readonly BrowsingService _BrowsingService;

        public BrowsingController(BrowsingService BrowsingService)
        {
            _BrowsingService = BrowsingService;
        }
        /// <summary>
        /// 获得浏览记录
        /// </summary>
        /// <returns></returns>
        // Get api/Browsing/
        [ResponseType(typeof(IEnumerable<BrowsingViewModel>))]
        [Route("api/v{version:apiVersion}/Browsing/")]
        public IHttpActionResult GetBrowsings()
        {
            List<Browsing> Browsings = _BrowsingService.GetEntrys(new Browsing()).ToList();
            List<BrowsingViewModel> BrowsingViewModels = new List<BrowsingViewModel>();
            foreach(Browsing b in Browsings)
            {
                BrowsingViewModels.Add(new BrowsingViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Url = b.Url,
                    Browser = b.Browser,
                    CreateDate = b.CreateDate,
                    UserId = b.UserId,
                    Tag = b.Tag
                 });
            }
            return Ok(BrowsingViewModels);
        }

        /// <summary>
        /// 获得指定的浏览记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // Get api/Browsing/Id
        [ResponseType(typeof(BrowsingViewModel))]
        //[MapToApiVersion("3.0")]
        [Route("api/v{version:apiVersion}/Browsing/{id}")]
        public IHttpActionResult GetBrowsing(string Id)
        {
            Guid guid = Guid.Empty;
            if (!Guid.TryParse(Id,out guid)){
                return NotFound();
            }
            var b = _BrowsingService.GetEntry(new Browsing { Id = Id });
            if (b == null)
            {
                return NotFound();
            }
            BrowsingViewModel bvm = new BrowsingViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Url = b.Url,
                Browser = b.Browser,
                CreateDate = b.CreateDate,
                UserId = b.UserId,
                Tag = b.Tag
            };
            return Ok(bvm);
        }

        /// <summary>
        /// 创建浏览记录
        /// </summary>
        /// <param name="browsing"></param>
        // Post api/Browsing/
        [Route("api/v{version:apiVersion}/Browsing/")]
        public void Create(CreateBrowsingBindingModel browsing) {
            Browsing b = new Browsing
            {
                Id = Guid.NewGuid().ToString(),
                Title = browsing.Title,
                Url = browsing.Url,
                Browser = browsing.Browser,
                CreateDate = DateTime.Now,
                Tag = browsing.Tag,
                UserId = browsing.UserId
            };
            _BrowsingService.AddEntry(b);
        }

        /// <summary>
        /// 更新浏览记录
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="browsing"></param>
        // Put api/Browsing/Id
        [Route("api/v{version:apiVersion}/Browsing/{id}")]
        public void Put(string Id, UpdateBrowsingBindingModel browsing) {

            Browsing b = new Browsing
            {
                Id = Id,
                Title = browsing.Title,
                Url = browsing.Url,
                Browser = browsing.Browser,
                CreateDate = browsing.CreateDate,
                UserId = browsing.UserId,
                Tag = browsing.Tag
            };
            _BrowsingService.UpdateEntry(b);
        }

        /// <summary>
        /// 删除指定浏览记录
        /// </summary>
        /// <param name="Id"></param>
        // DELETE api/Browsing/Id
        [Route("api/v{version:apiVersion}/Browsing/{id}")]
        public void Delete(string Id)
        {
            _BrowsingService.DeleteEntry(new Browsing { Id = Id });
        }

    }
}
