using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI
{
    /// <summary>
    /// 空对象
    /// </summary>
    public struct EmptyModel
    {
        /// <summary>
        /// 空
        /// </summary>
        public static EmptyModel Empty => new();
    }
}
