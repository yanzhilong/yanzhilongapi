using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilongapi.Models
{
    /// <summary>
    /// 创建浏览历史实体
    /// </summary>
    public class CreateBrowsingBindingModel
    {

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required(ErrorMessage = "用户编号必须要")]
        public string UserId { get; set; }

        /// <summary>
        /// 标签，用于区分当前用户的多个客户端
        /// </summary>
        [StringLength(100, ErrorMessage = "{0} 字段至少需要{2}个字符", MinimumLength = 6)]
        [Display(Name = "Tag 标签")]
        public string Tag { get; set; }
    }

    /// <summary>
    /// 修改浏览历史实体
    /// </summary>
    public class UpdateBrowsingBindingModel
    {

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required(ErrorMessage = "用户编号必须要")]
        public string UserId { get; set; }

        /// <summary>
        /// 标签，用于区分当前用户的多个客户端
        /// </summary>
        [StringLength(100, ErrorMessage = "{0} 字段至少需要{2}个字符", MinimumLength = 6)]
        public string Tag { get; set; }
    }
}