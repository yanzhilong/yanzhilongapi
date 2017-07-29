using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilongapi.Models
{

    /// <summary>
    /// 浏览历史实体
    /// </summary>
    public class Browsing
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

    }
}