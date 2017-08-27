using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilongapi.Models
{
    /// <summary>
    /// 填单属性实体
    /// </summary>
    public class JDPropertyViewModels
    {
        /// <summary>
        /// 属性key
        /// </summary>
        public string PropertyKey { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public string ValueValue { get; set; }

        /// <summary>
        /// 是否是check
        /// </summary>
        public bool IsCheck { get; set; }
    }
}