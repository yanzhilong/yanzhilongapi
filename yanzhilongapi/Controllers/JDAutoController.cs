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
    public class JDAutoController : ApiController
    {
        private readonly JdAutoService _JdAutoService;

        public JDAutoController(JdAutoService JdAutoService)
        {
            _JdAutoService = JdAutoService;
        }
        /// <summary>
        /// 获得浏览记录
        /// </summary>
        /// <returns></returns>
        // Get api/Browsing/
        [ResponseType(typeof(IEnumerable<JDAutoViewModels>))]
        [Route("api/v{version:apiVersion}/JdAutos/")]
        public IHttpActionResult GetJdAutos()
        {
            List<JdAuto> JdAutos = _JdAutoService.GetEntrys(new JdAuto()).ToList();
            List<JDAutoViewModels> JDAutoViewModels = new List<JDAutoViewModels>();
            foreach(JdAuto j in JdAutos)
            {
                JDAutoViewModels.Add(new JDAutoViewModels
                {
                    Id = j.Id,
                    Name = j.Name
                 });
            }
            return Ok(JDAutoViewModels);
        }
    }
}
