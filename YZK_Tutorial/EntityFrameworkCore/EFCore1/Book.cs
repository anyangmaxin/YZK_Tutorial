using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    public class Book
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime PubTime { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
    }
}
