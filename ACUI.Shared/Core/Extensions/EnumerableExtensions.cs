using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Shared.Core.Extensions
{
    /// <summary>
    /// Enumerable 扩展
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 便利
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null)
            {
                return;
            }

            foreach (T obj in items)
            {
                action?.Invoke(obj);
            }
        }
    }
}
