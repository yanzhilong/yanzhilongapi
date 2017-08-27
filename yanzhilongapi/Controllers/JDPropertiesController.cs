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
    /// 京东自填写属性接口
    /// </summary>
    [ApiVersion("1.0")]   
    public class JDPropertiesController : ApiController
    {
        private readonly JdAutoPropertyValueService _JdAutoPropertyValueService;

        public JDPropertiesController(JdAutoPropertyValueService JdAutoPropertyValueService)
        {
            _JdAutoPropertyValueService = JdAutoPropertyValueService;
        }
        

        /// <summary>
        /// 获得指定填单的属性列表
        /// </summary>
        /// <param name="JDAutoId"></param>
        /// <returns></returns>
        // Get api/Browsing?JDAutoId
        [ResponseType(typeof(JDPropertyViewModels))]
        //[MapToApiVersion("3.0")]
        [Route("api/v{version:apiVersion}/JdAutos/{Id}/JDProperties")]
        public IHttpActionResult GetJDProperties(string Id)
        {
            Guid guid = Guid.Empty;
            if (!Guid.TryParse(Id,out guid)){
                return NotFound();
            }
            List<JdAutoPropertyValue> JdAutoPropertyValues = _JdAutoPropertyValueService.GetEntrys(new JdAutoPropertyValue { JdAutoId = Id }).ToList();
            List<JDPropertyViewModels> JDPropertyViewModels = new List<JDPropertyViewModels>();
            foreach (JdAutoPropertyValue j in JdAutoPropertyValues)
            {
                JDPropertyViewModels.Add(new JDPropertyViewModels
                {
                    PropertyKey = j.PropertyKey,
                    ValueValue = j.ValueValue,
                    IsCheck = j.IsCheck == 1
                });
            }
            return Ok(JDPropertyViewModels);
        }

    }
}
