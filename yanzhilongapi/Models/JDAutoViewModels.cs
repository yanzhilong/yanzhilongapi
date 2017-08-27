using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilongapi.Models
{
    /// <summary>
    /// 京东填单实体
    /// </summary>
    public class JDAutoViewModels
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Name { get; set; }
    }
}