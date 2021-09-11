using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACUI
{
    /// <summary>
    /// 有内容组件基础
    /// </summary>
    public abstract class ACContentComponentBase<TContext> : ACComponentBase
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment<TContext> ChildContent { get; set; }
    }
}
